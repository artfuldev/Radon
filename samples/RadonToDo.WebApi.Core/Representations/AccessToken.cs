using Radon.Core.Annotations;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.AccessToken)]
    public class AccessToken : Representation, IHaveSelfLink
    {
        public string Token { get; set; }

        [LinkRelationType(LinkRelationTypes.Self)]
        public Link SelfLink { get; set; }
        [LinkRelationType(ApplicationLinkRelationTypes.User)]
        public Link UserLink { get; set; }

    }
}