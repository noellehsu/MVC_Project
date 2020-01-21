using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingCart.Models;
using MVC_ShoppingCart.ViewModels;
using MVC_ShoppingCart.Repositories;

namespace MVC_ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepository = new ProductRepository();


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