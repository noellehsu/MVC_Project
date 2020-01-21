using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst_Clone
{
    class Program
    {
        static void Main(string[] args)
        {
            /*初始化DbContext物件，DbContext類別是負責對資料庫作業，NorthwindConext繼承DbContext類別
              故透過NorthwindConext物件就可以對資料庫進行CRUD作業。*/
            var db = new NorthwndContext();

            //以LINQ 查詢EDM(實體資料模型)
            var products = from p in db.Products
                           select p;

            Console.WriteLine("產品資訊如下:");

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductID}, {p.ProductName}, {p.UnitPrice}, {p.UnitsInStock}");
            }

            Console.WriteLine("請按任一鍵後離開...");
            Console.ReadKey();

            //關閉EF資料庫連線，關閉NorthwindConext物件佔用的資料庫連線及資源
            db.Dispose();   

        }
    }
}
