using System.Collections.Generic;
using Radon.Core.Annotations;
using Radon.Core.Links;
using Radon.Core.Representations;

namespace RadonToDo.WebApi.Core.Representations
{
    [MediaType(MediaTypes.ToDoList)]
    public class ToDoList : PagedCollection<ToDoListItem>
    {
        public ToDoList(IEnumerable<ToDoListItem> list) : base(list)
        {
        }

        [LinkRelationType(ApplicationLinkRelationTypes.User)]
        public Link UserLink { get; set; }
    }
}
