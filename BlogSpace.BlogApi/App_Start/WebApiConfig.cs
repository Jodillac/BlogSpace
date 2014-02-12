using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BlogSpace.BlogApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{pageIndex}",
                defaults: new { pageIndex = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "CategoryApi",
               routeTemplate: "api/category/{category}/{controller}/{pageIndex}",
               defaults: new { category = RouteParameter.Optional, pageIndex = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "DetailApi",
               routeTemplate: "api/{controller}/{id}/{title}",
               defaults: new { id = RouteParameter.Optional, title = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "SearchApi",
               routeTemplate: "api/{controller}/{search}",
               defaults: new { search = RouteParameter.Optional }
           );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }


    }

}
