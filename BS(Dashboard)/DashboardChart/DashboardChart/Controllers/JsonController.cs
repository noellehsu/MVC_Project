using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DashboardChart.Models;

namespace DashboardChart.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Encode()
        {
            //1.Label
            string[] Months = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            //以ViewBag將資料傳給View
            ViewBag.MonthsLabel = Months;

            double[] Temperature = new double[] { 16.1, 16.5, 18.5, 21.9, 25.2, 27.7, 29.6, 29.2, 27.4, 24.5, 21.5, 17.9 };


            return View(Temperature);
        }
    }
}