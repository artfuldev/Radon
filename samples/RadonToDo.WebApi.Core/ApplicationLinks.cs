using System.Net.Http;
using Radon.Core.Links;

namespace RadonToDo.WebApi.Core
{
    public static class ApplicationLinks
    {
        public static readonly Link GetUserExitenceLink = new Link(Templates.UserExistence,
            ApplicationLinkRelationTypes.GetUserExistence, contentType: MediaTypes.User,
            method: HttpMethod.Get.ToString());

        public static readonly Link GetAccessTokensLink = new Link(Templates.AccessTokens,
            ApplicationLinkRelationTypes.AccessTokens, contentType: MediaTypes.AccessTokenCollection,
            method: HttpMethod.Get.ToString());

        public static readonly Link GetAccessTokenLink = new Link(Templates.AccessToken,
            ApplicationLinkRelationTypes.GetAccessToken, contentType: MediaTypes.AccessToken,
            method: HttpMethod.Get.ToString());

        public static readonly Link CreateAccessTokenLink = new Link(Templates.AccessTokens,
            ApplicationLinkRelationTypes.CreateAccessToken, contentType: MediaTypes.AccessToken,
            method: HttpMethod.Post.ToString());

        public static readonly Link GetUserLink = new Link(Templates.User, ApplicationLinkRelationTypes.GetUser,
            contentType: MediaTypes.User, method: HttpMethod.Get.ToString());

        public static readonly Link CreateUserLink = new Link(Templates.Users, ApplicationLinkRelationTypes.CreateUser,
            contentType: MediaTypes.User, method: HttpMethod.Post.ToString());

        public static readonly Link GetToDoListLink = new Link(Templates.ToDoList,
            ApplicationLinkRelationTypes.GetToDoList, contentType: MediaTypes.ToDoList,
            method: HttpMethod.Get.ToString());

        public static readonly Link ToDoListLink = new Link(Templates.ToDoList,
            ApplicationLinkRelationTypes.ToDoList, contentType: MediaTypes.ToDoListItem,
            method: HttpMethod.Post.ToString());

        public static readonly Link GetToDoListItemLink = new Link(Templates.ToDoListItem,
            ApplicationLinkRelationTypes.ToDoListItem, contentType: MediaTypes.ToDoListItem,
            method: HttpMethod.Get.ToString());

        public static readonly Link MarkToDoListItemDoneLink = new Link(Templates.ToDoListItem,
            ApplicationLinkRelationTypes.CompleteToDoListItem, contentType: MediaTypes.ToDoListItem,
            method: HttpMethod.Delete.ToString());
    }
}