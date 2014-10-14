namespace WebServicesExam.WebApi
{
    using System;
    using System.Web.Http;
    using Microsoft.Owin.Security.OAuth;
    using System.Web.Http.Cors;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Guess",
                routeTemplate: "api/games/{id}/guess",
                defaults: new
                {
                    controller = "Games",
                    action = "Guess"
                }
            );

            config.Routes.MapHttpRoute(
                name: "NextNotification",
                routeTemplate: "api/notifications/next",
                defaults: new
                {
                    controller = "Notifications",
                    action = "Next"
                }
            );

            config.Routes.MapHttpRoute(
                name: "ArticleDetails",
                routeTemplate: "api/notifications",
                defaults: new
                {
                    controller = "Notifications",
                    action = "Get"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Enable OData
            config.AddODataQueryFilter();

            // Json as default return type
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);            
        }
    }
}
