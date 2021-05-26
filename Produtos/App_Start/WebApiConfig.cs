using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SigWeb.App_Start
{
    /// <summary>
    /// Foi criado essa classe para que o Webservice Rest Funcione
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute(
            name: "ApiDefault", 
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional });
        }
        /*public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }*/
    }
}