using System;

namespace Radon.Client.Helpers
{
    /// <summary>
    /// Attribute used to denote that a string property should be serialized as a base64 encoded string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class SerializeAsBase64Attribute : Attribute
    {
    }
}
