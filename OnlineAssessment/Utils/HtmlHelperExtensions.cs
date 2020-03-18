using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace OnlineAssessment.Utils
{
    public static class HtmlHelperExtensions
    {
        public static string IsSelected(this IHtmlHelper htmlHelper, string controllers, string actions, string hreflang, string cssClass = "is-active")
        {

            var currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            var currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;
            var currentCulture = htmlHelper.ViewContext.RouteData.Values["lang"] as string;

            IEnumerable<string> acceptedActions = (actions ?? currentAction).Split(',');
            IEnumerable<string> acceptedControllers = (controllers ?? currentController).Split(',');

            return acceptedActions.Contains(currentAction) 
                    && acceptedControllers.Contains(currentController) 
                    && currentCulture.Equals(hreflang, StringComparison.InvariantCultureIgnoreCase)?
                cssClass : string.Empty;
            
        }

    }
}
