using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RESTEventVisitor
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CheckUserApi", //Profile
                routeTemplate: "api/{controller}/{action}/{id}", // api/MyProfile    api/MyProfile/Profile
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(                name: "DefaultApi", //Profile                routeTemplate: "api/{controller}/{id}", // api/MyProfile    api/MyProfile/Profile                defaults: new { id = RouteParameter.Optional }            );

        }
    }
}
