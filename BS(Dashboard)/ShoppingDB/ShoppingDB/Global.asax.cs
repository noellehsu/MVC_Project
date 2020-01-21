using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShoppingDB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //移除不必要的ViewEngine,只留RazorViewEngine
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //因為使用Bootstrap 4, 故用不到Bundle
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
