using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJsonWebAPI_Clone.Models;
using Newtonsoft.Json;

namespace MvcJsonWebAPI_Clone.Controllers
{
    public class VueController : Controller
    {
        // GET: Vue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VueApp1()
        {
            return View();
        }

        public ActionResult VueEmployeeTable()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee {Id = 1, Name="Alex",Email="OK@gmail.com"},
                new Employee {Id = 2, Name="Winter",Email="OK@gmail.com"},
                new Employee {Id = 3, Name="Noelle",Email="OK@gmail.com"}
            };

            //把List<Employee>轉成Json再傳給View(將C#物件序列列化成JSON格式資料)
            string jsonEmps = JsonConvert.SerializeObject(employees);
            ViewData["Employees"] = jsonEmps;

            return View();
        }

    }
}