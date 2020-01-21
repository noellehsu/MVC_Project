using MvcShoppingCart_Clone.Models;
using MvcShoppingCart_Clone.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShoppingCart_Clone.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public int AddToCart(ProductViewModel productVM)
        {
            List<Cart> cartItems = new List<Cart>(); 

            if (Session["Cart"] == null) //判斷Session["Cart"]存不存在
            {
                Cart cart = new Cart
                {
                    RecordId = 1,
                    CartId = Guid.NewGuid().ToString(), //產生一組長得很像SHA-1值的ID
                    ProductId = productVM.ProductId,
                    Price = productVM.Price,
                    Count = productVM.Count,
                    CreatedDate = DateTime.Now
                };

                cartItems.Add(cart);

            }
            else
            {
                cartItems = (List<Cart>)Session["Cart"]; //如果Session["Cart"]已存在，將Session中的購物車記錄還原成集合

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

                Session["CartItemCount"] = cart.RecordId; 
                //保持記錄著購物車的商品，因為Session是存在server裡的
            }

            //這邊設中斷點看看
            Session["Cart"] = cartItems; //購物車每新增一筆商品資料(cart)，RecordId會記錄裡面有幾筆資料


            return cartItems.Count;
        }

        //清空購物車
        public ActionResult ClearSession()
        {
            Session["Cart"] = null;
            Session["CartItemCount"] = null;

            return new EmptyResult(); //回傳Void的意思
        }

    }
}