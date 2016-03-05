using System;

namespace Radon.Core.Serialization
{
    /// <summary>
    ///     The member decorated with this attribute will be ignored during serialization
    ///     and deserialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SerializeIgnoreAttribute : Attribute
    {
    }
}