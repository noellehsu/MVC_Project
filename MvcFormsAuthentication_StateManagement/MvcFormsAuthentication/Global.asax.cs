using MvcFormsAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Configuration;

namespace MvcFormsAuthentication
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Application["CompanyName"] = "BuildSchool";
            //Application["Tel"] = "888999";

            Application["CompanyName"] = WebConfigurationManager.AppSettings["CompanyName"];
            Application["Tel"] = WebConfigurationManager.AppSettings["Tel"];

            //利用WebConfigurationManager抓到Web.config裡的<ConnectionStrings>
            Application["DBConnection"]=WebConfigurationManager.ConnectionStrings["AccountContext"];
        }

        //加入Global.asax 全域應用程式類別
        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["Product"] == null) //做點防呆，如果products資料在，就不用再執行一次
            {
                List<Product> products = new List<Product>
            {
                new Product{ProductID="1",Name="Bag",Price=1900},
                new Product{ProductID="2",Name="Book",Price=300}
            };
                Session["Product"] = products;   //執行Home/ProductList就會把存在Session的資料印出來
            }

            //新增一筆新的資料到Session
            List<Product> prod = (List<Product>)Session["Product"]; 
            prod.Add(new Product{ ProductID = "3", Name = "watch",Price = 2000});
            Session["Product"] = prod;

        }
    }
}

