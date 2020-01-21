using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using MvcJsonWebAPI_Clone.Models;
using MvcJsonWebAPI_Clone.Repository;

namespace MvcJsonWebAPI_Clone.Controllers
{
    public class DapperController : Controller
    {
        //資料從Repository拿
        EmployeeRepository empRepository = new EmployeeRepository();

        // GET: Dapper
        public ActionResult Index()
        {
            List<Emp> emps = empRepository.GetAllEmployees();
            return View(emps);
        }
    }
}