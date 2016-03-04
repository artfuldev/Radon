using System.Collections.Generic;

namespace Radon.Core.Links
{
    /// <summary>
    /// Denotes that this representation supports links
    /// </summary>
    public interface ISupportLinks
    {
         IReadOnlyList<Link> Links { get; } 
    }
}