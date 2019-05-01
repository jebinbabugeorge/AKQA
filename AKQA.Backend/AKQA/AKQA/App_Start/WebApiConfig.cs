using AKQA.Filters;
using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AKQA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
#if DEBUG
            var url = ConfigurationManager.AppSettings["cors:AllowedOrigins"].ToString();
            var cors = new EnableCorsAttribute(url, "*", "*");
            config.EnableCors(cors);
#endif
            // Web API configuration and services
            config.Filters.Add(new ValidateModelAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
