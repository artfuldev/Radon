using System.Collections.Generic;

namespace Radon.Core.Links
{
    /// <summary>
    /// Embedded links are used inside collections
    /// </summary>
    public interface ISupportEmbeddedLinks
    {
         IEnumerable<string> _links { get; set; } 
    }
}