using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFormsAuthentication.Models;
using MvcFormsAuthentication.Services;
using System.Web.Configuration;


namespace MvcFormsAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            List<Product> prod = (List<Product>)Session["Product"];
            prod.Add(new Product { ProductID = "4", Name = "book", Price = 2000 });
            Session["Product"] = prod;

            return RedirectToAction("ProductList");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Session["LoginStatus"] = null;

            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Encryption()
        {
            
            string password = "123456789";
            string MD5String = HashService.MD5Hash(password);
            string MD5Base64String = HashService.MD5HashBase64(password);
            string SHA1String = HashService.SHA1Hash(password);
            string SHA512String = HashService.SHA512Hash(password);

            ViewData["Password"] = password;
            ViewData["MD5"] = MD5String;
            ViewData["MD5Base64"] = MD5Base64String;
            ViewData["SHA1"] = SHA1String;
            ViewData["SHA512"] = SHA512String;

            return View();
        }

        public ActionResult ProductList() 
        {
            //這個string connection 是為了用監看式看裡面的內容跟<connectionString>是一樣的
            //其實string connection 裡的東西等於Application["DBConnection"]
            string connection = WebConfigurationManager.ConnectionStrings["AccountContext"].ToString();
            
            ViewBag.DBConnection = System.Web.HttpContext.Current.Application["DBConnection"].ToString();


            //傳給ViewBag要記得轉型成string
            ViewBag.CompanyName= System.Web.HttpContext.Current.Application["CompanyName"].ToString();
            ViewBag.Tel = System.Web.HttpContext.Current.Application["Tel"].ToString();


            //Session["Product"]是object，要轉型成List<Product>   
            List<Product> products = (List<Product>)Session["Product"];
            return View(products);
        }


    }
}