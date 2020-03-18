using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace OnlineAssessment.Utils
{
    public class LanguageRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("lang"))
            {
                return false;
            }

            string lang = values["lang"].ToString();
            if (!lang.Equals("en") && !lang.Equals("fr"))
                return false;
            else
                return true;
        }
    }
}