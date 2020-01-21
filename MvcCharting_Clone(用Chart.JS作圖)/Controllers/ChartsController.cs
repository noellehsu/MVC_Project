using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCharting_Clone.Models;
using MvcCharting_Clone.ViewModels;

namespace MvcCharting_Clone.Controllers
{
    public class ChartsController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        // 氣溫長條圖
        public ActionResult LineTemp()
        {
            return View();
        }

        // 三個城市的氣溫長條圖
        public ActionResult LineTemperature3()
        {
            return View();
        }

        //用不同方式傳遞資料
        public ActionResult LineTempData()
        {
            //1.Label
            string[] Months = { "一月","二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月",
                                "十一月","十二月"};
            //以ViewBag將資料傳給View
            ViewBag.MonthsLabel = Months;

            //2.C#泛型集合，包含台北，台中及高雄三個地方的氣溫資料
            List<Location> Locations = new List<Location>
            {
                new Location {
                    City="台北",
                    Temperature = new double[] { 16.1, 16.5, 18.5, 21.9, 25.2, 27.7, 29.6, 29.2, 27.4, 24.5, 21.5, 17.9 }
                },
                new Location{
                    City="台中",
                    Temperature = new double[] {16.6, 17.3, 19.6, 23.1, 26.0, 27.6, 28.6, 28.3, 27.4, 25.2, 21.9, 18.1}

                },
                new Location{
                    City="高雄",
                    Temperature = new double[]{19.3, 20.3, 22.6, 25.4, 27.5, 28.5, 29.2, 28.7, 28.1, 26.7, 24.0, 20.6 }
                }
            };


            /* 如果要實作ViewModel要這樣寫
            var mixVM = new MixViewModel
            {
                Months = Months,
                Locations = Locations,
            };
            return View(mixVM);
            */


            return View(Locations);
        }

    }
}