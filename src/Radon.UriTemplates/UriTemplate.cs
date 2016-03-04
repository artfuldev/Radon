using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radon.UriTemplates
{
    /// <summary>
    ///     URI template processor (RFC6570).
    /// </summary>
    public sealed class UriTemplate
    {
        private readonly List<IUriComponent> _components;
        private List<VarSpec> _variables;

        public UriTemplate(string template)
        {
            Ensure.ArgumentIsNotNull(template, nameof(template));

            Template = template;
            _components = UriTemplateParser.Parse(template);
        }

        internal UriTemplate(IEnumerable<IUriComponent> components)
        {
            Ensure.ArgumentIsNotNull(components, nameof(components));

            _components = new List<IUriComponent>(components);
            Template = GetTemplateString(_components);
        }

        public string Template { get; }

        public IEnumerable<VarSpec> Variables => _variables ?? (_variables = GetVariables(_components));

        internal IEnumerable<IUriComponent> Components => _components;

        public UriTemplateResolver GetResolver() => new UriTemplateResolver(this);

        public string Resolve(IDictionary<string, object> variables)
        {
            Ensure.ArgumentIsNotNull(variables, nameof(variables));

            var builder = new StringBuilder(Template.Length*2);

            try
            {
                foreach (var component in _components)
                {
                    component.Resolve(builder, variables);
                }
            }
            catch (UriTemplateException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new UriTemplateException("Error at resolve URI template.", exception);
            }

            return builder.ToString();
        }

        public Uri ResolveUri(IDictionary<string, object> variables)
        {
            return new Uri(Resolve(variables));
        }

        public UriTemplate ResolveTemplate(IDictionary<string, object> variables)
        {
            Ensure.ArgumentIsNotNull(variables, nameof(variables));

            if (variables.Count == 0)
            {
                return this;
            }

            var partialComponents = new List<IUriComponent>();

            try
            {
                foreach (var component in _components)
                {
                    partialComponents.AddRange(component.ResolveTemplate(variables));
                }
            }
            catch (UriTemplateException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new UriTemplateException("Error at partial resolve URI template.", exception);
            }

            return new UriTemplate(partialComponents);
        }

        public override string ToString()
        {
            return Template;
        }

        private static string GetTemplateString(List<IUriComponent> components)
        {
            var builder = new StringBuilder();

            foreach (var component in components)
            {
                builder.Append(component);
            }

            return builder.ToString();
        }

        private static List<VarSpec> GetVariables(List<IUriComponent> components)
        {
            var variables = new List<VarSpec>();

            foreach (var expression in components.OfType<Expression>())
            {
                variables.AddRange(expression.VarSpecs);
            }

            return variables;
        }
    }
}