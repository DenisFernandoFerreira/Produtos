using SigWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Produtos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration); // configuracao e rotas webapi
            RouteConfig.RegisterRoutes(RouteTable.Routes);// rotas mvc
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
