using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Radon.Core.Links;
using Radon.Core.Representations;
using Radon.Core.Serialization;
using Radon.Server.Helpers;
using Radon.UriTemplates;
using System.Linq;

namespace Radon.Server.Responses
{
    public class ApiResult<T> : ActionResult where T : IRepresentation
    {
        private readonly ISerializationService _serializer;
        private const string TotalCountHeaderKey = "Total-Count";
        private const string LinkHeaderKey = "Link";
        public ApiResult(ApiResponse<T> source) : this(source, null) { }
        public ApiResult(ApiResponse<T> source, ISerializationService serializer)
        {
            Response = source;
            _serializer = serializer ?? new SerializationService();
        }

        public ApiResponse<T> Response { get; set; }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            var representation = Response.Success
                ? (IRepresentation)Response.Result
                : Response.Error;

            var contentType = representation?.GetMediaType()
                // Response item is null
                // This will never happen for Response.Error so this must be null response without errors
                // But we still have to get the ContentType, so here goes
                ?? typeof(T).GetMediaType();

            // Set content type of response
            response.ContentType = contentType;

            // Set Response Code if !Response.Sucess, because response will treat as 200 Success
            if (!Response.Success)
                response.StatusCode = Convert.ToInt32(Response.Error.StatusCode);

            // Cast to required types to check against
            var selfLinked = representation as IHaveSelfLink;
            var collection = representation as IRepresentationCollection;
            var pagedCollection = representation as IPagedCollection;
            var linkHolder = representation as ISupportLinks;

            // Add Self Link if available and not set, eg: collection, paged collection, etc
            if (selfLinked != null && selfLinked.SelfLink == null)
            {
                var uri = request.Path + request.QueryString;
                var template = new UriTemplate(uri);
                selfLinked.SelfLink = new Link(template, contentType: contentType, method: request.Method);
            }

            // Add Embedded Links for Resources inside collections
            if (collection != null && request.Query["expand"] == "links")
            {
                try
                {
                    var enumerable = collection.OfType<ISupportEmbeddedLinks>();
                    foreach (var supportEmbeddedLinks in enumerable)
                    {
                        var linkSupporter = supportEmbeddedLinks as ISupportLinks;
                        if (linkSupporter == null) break;
                        var links = linkSupporter.Links.Select(x => x.LinkValue).ToList();

                        // Prevent serialization of empty links list
                        if (links.Count == 0)
                            links = null;

                        supportEmbeddedLinks._links = links;
                    }
                }
                catch
                {
                    // ignore, this should never happen
                }
            }

            // Add First and Last Links for Collections if they have self links
            // Paged Collections are also collections, so ignore them
            if (collection != null && pagedCollection == null)
            {
                try
                {
                    var haveSelfLinks = collection.OfType<IHaveSelfLink>().ToList();
                    var first = haveSelfLinks.FirstOrDefault();
                    if (first != null)
                        collection.FirstLink = first.SelfLink?.SetLinkRelationType(LinkRelationTypes.First);
                    var last = haveSelfLinks.LastOrDefault();
                    if (last != null)
                        collection.LastLink = last.SelfLink?.SetLinkRelationType(LinkRelationTypes.Last);
                }
                catch
                {
                    // ignore, this should never happen
                }
            }

            // Add Pagination Links for Paged Collections
            if (pagedCollection != null)
            {
                try
                {
                    var query = request.Query;

                    // Get page and items count
                    // uint parser;
                    var page = pagedCollection.Page; // uint.TryParse(query["page"] ?? "1", out parser) ? parser : 1;
                    var perPage = pagedCollection.PerPage; // uint.TryParse(query["perpage"] ?? "25", out parser) ? parser : 25;
                    var total = pagedCollection.TotalCount;

                    // Generate first, previous, next, last page numbers
                    uint first = 1,
                        last = total > perPage ? (total / perPage) + 1 : 1,
                        previous = page > 1 ? page - 1 : 1,
                        next = last > page ? page + 1 : last;

                    // first
                    if (page != first)
                    {
                        var parameters = new Dictionary<string, string> {{"page", first.ToString()}};
                        if (perPage != 25)
                            parameters.Add("perpage", perPage.ToString());
                        var queryString = query.SetQueryParameters(parameters);
                        pagedCollection.FirstLink = new Link(new UriTemplate(request.Path + queryString.ToString()),
                            LinkRelationTypes.First, contentType: contentType, method: request.Method);
                    }
                    // previous
                    if (page != first)
                    {
                        var parameters = new Dictionary<string, string> { { "page", previous.ToString() } };
                        if (perPage != 25)
                            parameters.Add("perpage", perPage.ToString());
                        var queryString = query.SetQueryParameters(parameters);
                        pagedCollection.PreviousLink = new Link(new UriTemplate(request.Path + queryString.ToString()),
                            LinkRelationTypes.Previous, contentType: contentType, method: request.Method);
                    }
                    // next
                    if (page != last)
                    {
                        var parameters = new Dictionary<string, string> { { "page", next.ToString() } };
                        if (perPage != 25)
                            parameters.Add("perpage", perPage.ToString());
                        var queryString = query.SetQueryParameters(parameters);
                        pagedCollection.NextLink = new Link(new UriTemplate(request.Path + queryString.ToString()),
                            LinkRelationTypes.Next, contentType: contentType, method: request.Method);
                    }
                    // last
                    if (page != last)
                    {
                        var parameters = new Dictionary<string, string> { { "page", last.ToString() } };
                        if (perPage != 25)
                            parameters.Add("perpage", perPage.ToString());
                        var queryString = query.SetQueryParameters(parameters);
                        pagedCollection.LastLink = new Link(new UriTemplate(request.Path + queryString.ToString()),
                            LinkRelationTypes.Last, contentType: contentType, method: request.Method);
                    }

                    // Total Count
                    var totalCount = new[] { pagedCollection.TotalCount.ToString() };
                        response.Headers.Add(TotalCountHeaderKey, totalCount);
                }
                catch
                {
                    // ignore, this should never happen
                }
            }


            // Add Link Headers
            var linkValues = linkHolder?.Links.Select(x => x.LinkValue).ToArray();
            if (linkValues?.Length > 0)
                response.Headers.Add("Link", linkValues);

            // Write only Response Body or Error, don't encapsulate
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(_serializer.Serialize(representation)));
            await stream.CopyToAsync(response.Body);
        }
    }
}