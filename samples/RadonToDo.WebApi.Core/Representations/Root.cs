using Radon.Core.Annotations;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.Root)]
    public class Root : Representation
    {

        [LinkRelationType(ApplicationLinkRelationTypes.AccessTokens)]
        public Link AccessTokens { get; set; }

        [LinkRelationType(ApplicationLinkRelationTypes.CreateAccessToken)]
        public Link CreateAccessToken { get; set; }

        [LinkRelationType(ApplicationLinkRelationTypes.GetUser)]
        public Link GetUser { get; set; }

        [LinkRelationType(ApplicationLinkRelationTypes.CreateUser)]
        public Link CreateUser { get; set; }
        public static readonly Root Default = new Root()
        {
            AccessTokens = ApplicationLinks.GetAccessTokensLink,
            CreateAccessToken = ApplicationLinks.CreateAccessTokenLink,
            GetUser = ApplicationLinks.GetUserLink,
            CreateUser = ApplicationLinks.CreateUserLink
        };
    }
}