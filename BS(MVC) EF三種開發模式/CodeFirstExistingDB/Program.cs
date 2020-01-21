using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistingDB
{
    class Program
    {
        //這個練習是從資料庫產出Models
        static void Main(string[] args)
        {
            //初始化DbContext實體
            using (var context = new NorthwindContext())
            {
                var products = from p in context.Products
                               select p;

                //讀取products中的項目
                foreach(var item in products)
                {
                    Console.WriteLine($"{item.ProductID},{item.ProductName},{item.UnitPrice}");
                }

                Console.WriteLine("請按任一鍵離開...");
                Console.ReadKey();

            }


        }
    }
}
