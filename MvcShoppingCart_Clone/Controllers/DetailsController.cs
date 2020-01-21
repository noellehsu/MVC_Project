using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcShoppingCart_Clone.Repositories;
using MvcShoppingCart_Clone.ViewModels;


namespace MvcShoppingCart_Clone.Controllers
{
    public class DetailsController : Controller
    {
        ProductRepository repo = new ProductRepository();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult FindProductById(string productId)
        {
            //防呆
            if (string.IsNullOrEmpty(productId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //每個商品做成單個ProductDetail
            ProductViewModel productVM = repo.GetProductById(productId);

            if (productVM == null)
            {
                return HttpNotFound();
            }



            return View(productVM);
        }

    }
}