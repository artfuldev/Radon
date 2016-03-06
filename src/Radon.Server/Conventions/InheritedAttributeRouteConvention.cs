using System;
using System.Reflection;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ApplicationModels;
using Microsoft.AspNet.Mvc.Infrastructure;
using System.Linq;

namespace Radon.Server.Conventions
{
    public class InheritedAttributeRouteConvention : IApplicationModelConvention
    {
        private readonly Func<TypeInfo, bool> _predicate;

        public InheritedAttributeRouteConvention(Type baseType, string routeTemplate) :
            this(t => baseType.GetTypeInfo().IsAssignableFrom(t), routeTemplate)
        {
        }

        public InheritedAttributeRouteConvention(Type baseType, IRouteTemplateProvider route) :
            this(t => baseType.GetTypeInfo().IsAssignableFrom(t), route)
        {
        }

        public InheritedAttributeRouteConvention(Func<TypeInfo, bool> typePredicate, string routeTemplate)
            : this(typePredicate, new RouteAttribute(routeTemplate))
        {
            Route = new RouteAttribute(routeTemplate);
            _predicate = typePredicate;
        }

        public InheritedAttributeRouteConvention(Func<TypeInfo, bool> typePredicate, IRouteTemplateProvider route)
        {
            Route = route;
            _predicate = typePredicate;
        }

        private IRouteTemplateProvider Route { get; }

        public void Apply(ApplicationModel application)
        {
            foreach (
                var controller in
                    application.Controllers.Where(controller => _predicate(controller.ControllerType))
                        .Where(controller => controller.AttributeRoutes.Count == 0))
            {
                controller.AttributeRoutes.Add(new AttributeRouteModel(Route));
            }
        }
    }

    public class InheritedAttributeRouteConvention<TControllerBaseType> : InheritedAttributeRouteConvention
    {
        public InheritedAttributeRouteConvention(string route) : base(typeof (TControllerBaseType), route)
        {
        }
    }
}