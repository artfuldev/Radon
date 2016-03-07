using System;

namespace RadonToDo.WebApi.Core.ErrorCodes
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class ErrorCodePrefixAttribute : Attribute
    {
        public int Prefix { get; set; }

        public ErrorCodePrefixAttribute(int prefix)
        {
            Prefix = prefix;
        }
    }
}