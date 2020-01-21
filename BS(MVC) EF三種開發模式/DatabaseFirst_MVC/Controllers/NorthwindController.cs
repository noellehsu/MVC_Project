using DatabaseFirst_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DatabaseFirst_MVC.Controllers
{
    public class NorthwindController : Controller
    {
        //NorthwindContext不能放在ShowData()裡面
        NorthwindContext db = new NorthwindContext();


        // GET: Northwind
        public ActionResult ShowData()
        {
            //如果我不想要Products全部的欄位，只想要部分欄位，要用ViewModel去定義
            var products = from p in db.Products
                           select p;

            return View(products.ToList());
            //ToList()可以把IQueryable變成一個集合
        }


        //用ViewModel傳資料給View
        public ActionResult ProductList()
        {

            var products = from p in db.Products
                           select new ProductViewModel
                           {
                               Id = p.ProductID,
                               Name = p.ProductName,
                               UnitPrice = (decimal)p.UnitPrice,
                               //Tax = (decimal)p.UnitPrice * (decimal)1.05,
                               UnitsInStock = (int)p.UnitsInStock
                               //這邊再轉型一次，雖然有在ViewModel定義decimal，但資料庫不一定讀的到
                           };

            List<ProductViewModel> productsVM = products.ToList();
            return View(productsVM);
        }


        [HttpGet]
        public ActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id); //找到產品
            if (product == null)
            {
                return HttpNotFound();
            }

            //---------以上是從Scaffold複製來的，以下是我自己打的---------
            ProductViewModel productVM = new ProductViewModel
            {
                Id = product.ProductID,
                Name = product.ProductName,
                UnitPrice = (decimal)product.UnitPrice,
                UnitsInStock = (int)product.UnitsInStock
            };

            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit([Bind(Include = "Id,Name,UnitPrice,UnitsInStock")] ProductViewModel productViewModel)
        {
            return View();

        }




    }

}