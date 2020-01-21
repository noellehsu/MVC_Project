using MvcJsonWebAPI_Clone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcJsonWebAPI_Clone.Helpers;

namespace MvcJsonWebAPI_Clone.Controllers
{
    public class JsonDataAPIController : Controller
    {
        // GET: JsonDataAPI
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployees() //JsonResult也可以寫成ActionResult
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {Id=1,Name="Kevin",Email="abc@gmail.com"},
                new Employee {Id=2,Name="David",Email="abc@gmail.com"},
                new Employee {Id=3,Name="Mary",Email="abc@gmail.com"}

            };

            //前端如以GET方法呼叫,如jQuery.get()或getJSON(),需開啟JsonRequestBehavior.AllowGet設定
            //return Json跟return View只能選一個
            //return Json(employees, JsonRequestBehavior.AllowGet);
            return Json(employees, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);

        }

        //回傳BMW & BENZ汽車銷售數字的JSON
        public ActionResult GetCarSalesNumber()
        {
            List<CarSales> CarSalesNumber = new List<CarSales>
              {
                  new CarSales { Id = 1, Car = "BMW", Salesdata = new int[] { 120, 200, 300, 350, 400, 250, 380, 330, 500, 280, 310, 330 } },
                  new CarSales { Id = 2,  Car = "BENZ", Salesdata = new int[] { 220, 150, 350, 300, 300, 200, 180, 400, 420, 210, 250, 440 }},
              };
            //前端如以GET方法呼叫,如jQuery.get()或getJSON(),需開啟JsonRequestBehavior.AllowGet設定
            return Json(CarSalesNumber, JsonRequestBehavior.AllowGet);
        }

        //以亂數產生1-12月汽車銷售數據
        public ActionResult getCarSalesNumberRandom()
        {
           
            Utility util = new Utility(); //我寫在Helpers的Utility用來產生整數陣列
            var random1 = util.getNumbers(12);
            var random2 = util.getNumbers(12);


            List<CarSales> CarSalesNumber = new List<CarSales>
            {
                new CarSales { Id = 1438, Car = "Audi", Salesdata = random1 },
                new CarSales { Id = 9563, Car = "Lexus", Salesdata = random2 },
            };

            return Json(CarSalesNumber, JsonRequestBehavior.AllowGet);
        }

        //以jQuery Ajax呼叫各種類型遠端API，取回JSON格式的汽車銷售資料
        public ActionResult CarSalesAjaxJSON()
        {
            return View();
        }


    }
}