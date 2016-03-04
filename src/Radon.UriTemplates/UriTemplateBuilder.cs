using System;
using System.Collections.Generic;

namespace Radon.UriTemplates
{
    /// <summary>
    ///     Used to effective programmatically construct URI template.
    /// </summary>
    public class UriTemplateBuilder
    {
        private readonly List<IUriComponent> _components;

        public UriTemplateBuilder()
        {
            _components = new List<IUriComponent>();
        }

        public UriTemplateBuilder(string template)
            : this(new UriTemplate(template))
        {
        }

        public UriTemplateBuilder(UriTemplate template)
        {
            Ensure.ArgumentIsNotNull(template, nameof(template));

            _components = new List<IUriComponent>(template.Components);
        }

        public UriTemplateBuilder(UriTemplateBuilder builder)
        {
            Ensure.ArgumentIsNotNull(builder, nameof(builder));

            _components = new List<IUriComponent>(builder._components);
        }

        public UriTemplateBuilder Literal(string value)
        {
            Ensure.ArgumentIsNotNull(value, nameof(value));

            _components.Add(new Literal(value));
            return this;
        }

        public UriTemplateBuilder Simple(params VarSpec[] vars)
        {
            return Expression(Operator.Default, vars);
        }

        public UriTemplateBuilder Reserved(params VarSpec[] vars)
        {
            return Expression(Operator.Reserved, vars);
        }

        public UriTemplateBuilder Fragment(params VarSpec[] vars)
        {
            return Expression(Operator.Fragment, vars);
        }

        public UriTemplateBuilder Label(params VarSpec[] vars)
        {
            return Expression(Operator.Label, vars);
        }

        public UriTemplateBuilder Matrix(params VarSpec[] vars)
        {
            return Expression(Operator.Matrix, vars);
        }

        public UriTemplateBuilder Path(params VarSpec[] vars)
        {
            return Expression(Operator.Path, vars);
        }

        public UriTemplateBuilder Query(params VarSpec[] vars)
        {
            return Expression(Operator.Query, vars);
        }

        public UriTemplateBuilder QueryContinuation(params VarSpec[] vars)
        {
            return Expression(Operator.Continuation, vars);
        }

        public UriTemplateBuilder Expression(char exprOperator, params VarSpec[] vars)
        {
            var op = Operator.Parse(exprOperator);
            return Expression(op, vars);
        }

        public UriTemplateBuilder Clear()
        {
            _components.Clear();
            return this;
        }

        public UriTemplate Build()
        {
            return new UriTemplate(_components);
        }

        private UriTemplateBuilder Expression(Operator op, params VarSpec[] vars)
        {
            Ensure.ArgumentIsNotNull(vars, nameof(vars));

            var varsList = new List<VarSpec>(vars.Length);
            varsList.AddRange(vars);
            var expression = new Expression(op, varsList);
            _components.Add(expression);
            return this;
        }
    }
}