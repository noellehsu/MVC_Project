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

            //�Q��WebConfigurationManager���Web.config�̪�<ConnectionStrings>
            Application["DBConnection"]=WebConfigurationManager.ConnectionStrings["AccountContext"];
        }

        //�[�JGlobal.asax �������ε{�����O
        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["Product"] == null) //���I���b�A�p�Gproducts��Ʀb�A�N���ΦA����@��
            {
                List<Product> products = new List<Product>
            {
                new Product{ProductID="1",Name="Bag",Price=1900},
                new Product{ProductID="2",Name="Book",Price=300}
            };
                Session["Product"] = products;   //����Home/ProductList�N�|��s�bSession����ƦL�X��
            }

            //�s�W�@���s����ƨ�Session
            List<Product> prod = (List<Product>)Session["Product"]; 
            prod.Add(new Product{ ProductID = "3", Name = "watch",Price = 2000});
            Session["Product"] = prod;

        }
    }
}

