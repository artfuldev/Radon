using Radon.Core.Annotations;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.User)]
    public class User : Representation, IHaveSelfLink
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [LinkRelationType(LinkRelationTypes.Self)]
        public Link SelfLink { get; set; }
        [LinkRelationType(ApplicationLinkRelationTypes.AccessTokens)]
        public Link AccessTokensLink { get; set; }
        [LinkRelationType(ApplicationLinkRelationTypes.CreateAccessToken)]
        public Link CreateAccessTokenLink { get; set; }

    }
}