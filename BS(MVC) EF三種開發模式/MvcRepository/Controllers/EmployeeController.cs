using MvcRepostitory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRepostitory.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        EmployeeRepository repo = new EmployeeRepository();

        //Action呼叫Repository類別裡面的方法(不用懂EF也能寫架構，看不出後端資料庫長怎樣)
        public ActionResult ListAllEmployees()
        {
            return View(repo.GetAllEmployee());
        }
    }
}