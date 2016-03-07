using System.Collections.Generic;
using Radon.Core.Annotations;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.AccessTokenCollection)]
    public class AccessTokenCollection : RepresentationCollection<AccessToken>
    {
        public AccessTokenCollection(IEnumerable<AccessToken> list) : base(list)
        {
        }
    }
}