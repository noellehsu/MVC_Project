using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingCart.Repositories;
using MVC_ShoppingCart.ViewModels;

namespace MVC_ShoppingCart.Controllers
{
    public class DetailsController : Controller
    {
        ProductRepository pRepository = new ProductRepository();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindProductById(string productId)
        {
            if(string.IsNullOrEmpty(productId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductViewModel productVM = pRepository.GetProductById(productId);

            if(productVM == null)
            {
                return HttpNotFound();
            }

            return View(productVM);
        }
    }
}