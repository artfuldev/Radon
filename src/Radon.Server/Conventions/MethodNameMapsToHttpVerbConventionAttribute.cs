using System;
using System.Linq;
using Microsoft.AspNet.Mvc.ApplicationModels;

namespace Radon.Server.Conventions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MethodNameMapsToHttpVerbConventionAttribute : Attribute, IControllerModelConvention
    {
        private static readonly string[] SupportedHttpVerbs = {
            "GET",
            "PUT",
            "POST",
            "DELETE",
            "PATCH",
            "HEAD",
            "OPTIONS"
        };

        public void Apply(ControllerModel controller)
        {
            foreach (var action in controller.Actions)
            {
                Apply(action);
            }
        }

        private static void Apply(ActionModel action)
        {
            // If the HttpMethods are set from attributes, don't override it with the convention
            if (action.HttpMethods.Count > 0)
            {
                return;
            }

            // The Method name is used to infer verb constraints. Changing the action name has not impact.
            foreach (
                var verb in
                    SupportedHttpVerbs.Where(
                        verb => action.ActionMethod.Name.StartsWith(verb, StringComparison.OrdinalIgnoreCase)))
            {
                action.HttpMethods.Add(verb);
                return;
            }

            // If no convention matches, then assume POST
            action.HttpMethods.Add("POST");
        }
    }
}