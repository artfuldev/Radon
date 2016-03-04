namespace Radon.Core.Links
{
    public interface IHaveSelfLink
    {
        [LinkRelationType(LinkRelationTypes.Self)]
        Link SelfLink { get; set; } 
    }
}