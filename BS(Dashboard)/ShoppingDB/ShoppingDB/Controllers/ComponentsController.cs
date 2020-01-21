using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingDB.Models;

namespace ShoppingDB.Controllers
{
    public class ComponentsController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        // GET: Components
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Carousel()
        {
            ViewData["CycleSeconds"] = 2000;

            return View(db.Carousel.ToList());
        }


        public ActionResult CarouselCaptionData()
        {
            List<Asset> assets = new List<Asset>
            {
                new Asset { Id=1, Title="冰島海岸", Description="水一天色的風景優美勝地", Photo="Slide1.jpeg"  },
                new Asset { Id=2, Title="紐西蘭海岸", Description="著名的電影拍攝場景", Photo="Slide2.jpeg"  },
                new Asset { Id=3, Title="沙岸小舟", Description="我和初戀情人約會的地方", Photo="Slide3.jpeg"  },
            };

            ViewData["CycleSeconds"] = 2000;

            return View(assets.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}