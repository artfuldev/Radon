using System;

namespace Radon.Core.Annotations
{
    public sealed class MediaTypeAttribute : Attribute
    {
        public MediaTypeAttribute(string mediaType)
        {
            MediaType = mediaType;
        }

        public string MediaType { get; }

    }
}