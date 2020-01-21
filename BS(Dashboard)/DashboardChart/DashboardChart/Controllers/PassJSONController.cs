using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DashboardChart.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DashboardChart.Controllers
{
    public class PassJSONController : Controller
    {
        private DashboardChartContext db = new DashboardChartContext();

        // GET: PassJSON
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PassClothingData()
        {
            //Photos File Name
            //string[] photos = new string[] { "40479_D_21.jpg", "40479_D_22.jpg", "40479_D_24.jpg", "40479_D_25.jpg", "40479_D_26.jpg", "19SS_760WASH_TW.jpg" };
            string[] photos = { "40479_D_21.jpg", "40479_D_22.jpg", "40479_D_24.jpg", "40479_D_25.jpg", "40479_D_26.jpg", "19SS_760WASH_TW.jpg" };
            string photosJSON = JsonConvert.SerializeObject(photos);

            //ClothingData
            List<Clothing> clothings = new List<Clothing>
            {
                new Clothing { ClothingId=40479011, Description="牛仔長袖襯衫-女（ 淺藍 -S）", Size=Size.S, UnitInStock=5 },
                new Clothing { ClothingId=40479012, Description="牛仔長袖襯衫-女（ 淺藍 -M）", Size=Size.M, UnitInStock=8 },
                new Clothing { ClothingId=40479013, Description="牛仔長袖襯衫-女（ 淺藍 -L）", Size=Size.L, UnitInStock=10 },
                new Clothing { ClothingId=40479014, Description="牛仔長袖襯衫-女（ 淺藍 -XL）", Size=Size.XL, UnitInStock=9 },
                new Clothing { ClothingId=40479015, Description="牛仔長袖襯衫-女（ 淺藍 -XXL）", Size=Size.XXL, UnitInStock=3 }
            };

            var p1 = clothings.First();

            //用列舉值反查名稱
            string SizeName = Enum.GetName(typeof(Size), p1.Size);


            Product product = new Product
            {
                ProductId = 4047901,
                Price = 450,
                PhotosJson = photosJSON,
                Clothings = clothings
            };

            Product product2 = new Product
            {
                ProductId = 4047901,
                Price = 450,
                PhotosJson = photosJSON,
                Clothings = new List<Clothing>
                {
                    new Clothing { ClothingId = 40479011, Description = "牛仔長袖襯衫-女（ 淺藍 -S）", Size = Size.S, UnitInStock = 5 },
                    new Clothing { ClothingId = 40479012, Description = "牛仔長袖襯衫-女（ 淺藍 -M）", Size = Size.M, UnitInStock = 8 },
                    new Clothing { ClothingId = 40479013, Description = "牛仔長袖襯衫-女（ 淺藍 -L）", Size = Size.L, UnitInStock = 10 },
                    new Clothing { ClothingId = 40479014, Description = "牛仔長袖襯衫-女（ 淺藍 -XL）", Size = Size.XL, UnitInStock = 9 },
                    new Clothing { ClothingId = 40479015, Description = "牛仔長袖襯衫-女（ 淺藍 -XXL）", Size = Size.XXL, UnitInStock = 3 }
                }
            };

            return View(product);
        }

        public async Task<ActionResult> PassClothingFromDB()
        {
            //這裡Include會有Self Reference Loop參考迴圈的問題
            //在Debug模式中觀察是哪一個Property引起參考迴圈，在該欄位套用[JsonIgnore]
            Product product = await db.Products.Include(x=>x.Clothings).SingleOrDefaultAsync(x => x.ProductId == 4047901);

            return View(product);
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