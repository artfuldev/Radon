using Radon.Core.Annotations;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.ToDoListItem)]
    public class ToDoListItem : Representation
    {
        public string Uri { get; set; }
        [LinkRelationType(ApplicationLinkRelationTypes.User)]
        public Link UserLink { get; set; }
    }
}
