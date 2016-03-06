using System;
using System.Reflection;
using Microsoft.AspNet.Mvc.ApplicationModels;
using System.Linq;

namespace Radon.Server.Conventions
{
    /// <summary>
    /// Add this using
    /// <code>
    /// services.Configure&lt;MvcOptions&gt;(options =>
    /// { 
    ///     options.ApplicationModelConventions.Add(
    ///         new VerbControllerApplicationConvention&lt;[controller]&gt;()); 
    ///             // apply verb convention to all controllers deriving from [controller].
    /// });
    /// </code>
    /// </summary>
    public class MethodNameMapsToHttpVerbConvention : IApplicationModelConvention
    {
        private readonly Func<TypeInfo, bool> _predicate;

        public MethodNameMapsToHttpVerbConvention(Type baseType)
            : this(t => baseType.GetTypeInfo().IsAssignableFrom(t))
        {
        }

        public MethodNameMapsToHttpVerbConvention(Func<TypeInfo, bool> typePredicate)
        {
            _predicate = typePredicate;
        }

        public void Apply(ApplicationModel application)
        {
            var convention = new MethodNameMapsToHttpVerbConventionAttribute();

            foreach (var controller in application.Controllers.Where(c => _predicate(c.ControllerType)))
            {
                convention.Apply(controller);
            }
        }
    }

    public class MethodNameMapsToHttpVerbConvention<TControllerBaseType> : MethodNameMapsToHttpVerbConvention
    {
        public MethodNameMapsToHttpVerbConvention() : base(typeof (TControllerBaseType))
        {
        }
    }
}