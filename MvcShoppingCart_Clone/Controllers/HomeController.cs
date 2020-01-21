using MvcShoppingCart_Clone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShoppingCart_Clone.Repositories;

namespace MvcShoppingCart_Clone.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepository = new ProductRepository();


        //去叫productRepository的方法，抓資料
        public ActionResult Index()
        { 

            return View(productRepository.GetAllProducts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}