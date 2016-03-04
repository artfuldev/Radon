using System.Collections.Generic;
using System.Text;

namespace Radon.UriTemplates
{
    internal class Literal : IUriComponent
    {
        public Literal(string value)
        {
            Ensure.ArgumentIsNotNull(value, nameof(value));

            Value = value;
        }

        public string Value { get; }

        public void Resolve(StringBuilder builder, IDictionary<string, object> variables)
        {
            builder.Append(Value);
        }

        public IEnumerable<IUriComponent> ResolveTemplate(IDictionary<string, object> variables)
        {
            return new IUriComponent[] {this};
        }

        public override string ToString()
        {
            return Value;
        }
    }
}