using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_ShoppingCart.Models;
using MVC_ShoppingCart.ViewModels;

namespace MVC_ShoppingCart.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int AddToCart(ProductViewModel productVM)
        {
            List<Cart> cartItems = new List<Cart>();

            if (Session["Cart"] ==null)
            {
                Cart cart = new Cart
                {
                    RecordId = 1,
                    CartId = Guid.NewGuid().ToString(),    
                    ProductId = productVM.ProductId,
                    Price = productVM.Price,
                    Count = productVM.Count,
                    CreatedDate = DateTime.Now
                };

                cartItems.Add(cart);

                Session["Cart"] = cartItems;
            }
            else
            {
                cartItems = (List<Cart>)Session["Cart"]; //將Session中的購物車記錄還原成集合

                Cart cart = new Cart
                {
                    RecordId = cartItems.Count() + 1,
                    CartId = Guid.NewGuid().ToString(),
                    ProductId = productVM.ProductId,
                    Price = productVM.Price,
                    Count = productVM.Count,
                    CreatedDate = DateTime.Now
                };

                cartItems.Add(cart);

                Session["Cart"] = cartItems;
            }


            return cartItems.Count;
        }
    }
}