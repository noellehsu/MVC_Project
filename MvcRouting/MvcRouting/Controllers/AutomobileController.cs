using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRouting.Models;
using System.Net;
using System.Reflection;
using System.Web.UI;

namespace MvcJqueryMobile.Controllers
{
    public class AutomobileController : Controller
    {
        CarContext db = new CarContext();

        public AutomobileController()
        {
            ViewBag.Cache = "快取時間: " + DateTime.Now.ToLongTimeString();
        }

        //顯示所有汽車資料
        //[OutputCache(Duration = 60, VaryByParam = "none", Location = OutputCacheLocation.Any)]
        public ActionResult List()
        {
            //讀取Cars資料表，並依Category車類型排序
            var cars = db.Cars.OrderBy(x => x.Category).ToList();
            return View(cars);
        }

        //與路由1「Car」對應
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            
            return View();
        }

        //與路由2「Car/Brand/{brand}」對應
        //以品牌找尋汽車
        //[OutputCache(Duration = 60, Location = OutputCacheLocation.Any)]
        //[OutputCache(Duration = 60)]
        public ActionResult FindBrand(string brand)
        {
            List<Car> cars = null;

            if (string.IsNullOrEmpty(brand) || brand.Trim().ToUpper()=="ALL")
            {
                //找出所有品牌汽車
                cars = (from c in db.Cars
                        select c).ToList();

                ViewBag.Header = "所有品牌汽車";
            }
            else
            {
                //找出該品牌汽車
                cars = (from c in db.Cars
                        where c.Brand == brand
                        select c).ToList();
            }

            if (cars.Count == 0)
            {
                return Content("找不到此品牌汽車");
            }
            else
            {
                ViewBag.Header = cars[0].Brand;
            }

            return View(cars);
        }

        //與路由3「Car/Cat/{category}」對應
        //以分類查詢汽車
        [OutputCache(Duration = 60, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult FindCategory(string cat)
        {
            if (string.IsNullOrEmpty(cat))
            {
                return Content("請提供汽車分類名稱!");
            }

            //找出所有該類型汽車
            var cars = (from c in db.Cars
                        where c.Category == cat
                        select c).ToList();

            if (cars.Count == 0)
            {
                return Content("找不到此類型的車!");
            }

            return View(cars);
        }

        //與路由4「Car/Id/{id}」對應
        //以Id編號查詢汽車
        //[OutputCache(Duration = 60, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult FindId(int? Id)
        {
            if (Id == null)
            {
                return Content("請提供汽車Id!");
            }

            Car car = db.Cars.Find(Id);
            if (car == null)
            {
                return Content("查無此Id編號汽車!"); 
            }

            return View(car);
        }


        //與路由5「Car/Year/{year}」對應
        //以年份找尋汽車
        //[OutputCache(Duration = 60, Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult FindYear(int? year)
        {
            if (year == null)
            {
                return Content("找車請提供年份!");
            }

            //找出所有該類型汽車
            var cars = (from c in db.Cars
                        where c.Year == year
                        orderby c.Brand
                        select c).ToList();

            if (cars.Count == 0)
            {
                //return HttpNotFound("Can not find any car of this year.");
                return Content("找不到這年份的車!");
            }

            return View(cars);
        }


        //與路由6「Car/Brand-Year/{brand}-{year}」對應
        //以品牌及年份的組合找尋汽車
        //[OutputCache(Duration = 60, Location = OutputCacheLocation.Downstream)]
        [OutputCache(Duration = 60)]
        public ActionResult FindBrandYear(string brand, int year)
        {
            List<Car> cars = (from c in db.Cars
                              where c.Brand == brand && c.Year == year
                              select c).ToList();

            if (cars.Count == 0)
            {
                return Content("找不到此Brand-Year汽車");
            }

            ViewBag.Header = brand;

            return View("FindBrand", cars);
        }

        //與路由7「Car/TopSales/{topnumber}」對應
        //查詢銷售前幾名汽車
        //[OutputCache(Duration = 60, Location = OutputCacheLocation.Downstream)]
        public ActionResult TopSales(int topnumber)
        {
            //找出所有該類型汽車
            var cars = (from c in db.Cars
                        orderby c.SoldNumber descending
                        select c).Take(topnumber).ToList();

            if (cars.Count == 0)
            {
                //return HttpNotFound("Can not find any car of this year.");
                return Content("找不到Top Sales數據!");
            }

            ViewBag.TopSales = topnumber;
            return View(cars);
        }

        public ActionResult GetRouteData(string RouteParam)
        {
            //讀取Request請求的URL
            var RawUrl = Request.RawUrl;
            var rawUrl = HttpContext.Request.RawUrl;
            var rawurl = ControllerContext.RequestContext.HttpContext.Request.RawUrl;

            //因為路由的Url屬性為非公開成員, 故透過Reflection讀取Url Pattern設定值
            var route = RouteData.Route;
            var UrlPattern = route.GetType().GetProperty("Url").GetValue(route);

            //透過RouteData.Values讀取路由參數
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var routeParameter = RouteData.Values["RouteParam"];

            /*這樣也能讀取
            var Controller = ControllerContext.RouteData.Values["controller"];
            var Action = ControllerContext.RouteData.Values["action"];
            var RouteParameter = ControllerContext.RouteData.Values["RouteParam"];
            */

            return View();
        }

        //[OutputCache(Duration =120, VaryByParam ="none", Location =OutputCacheLocation.Any)]
        public ActionResult Repair()
        {
            return View();
        }
    }
}