using System;
using System.Linq;

namespace EF_CodeFirstExistingDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化DbContext實體
            using (var context = new NorthwindDataModel())
            {
                //以LINQ查詢DbContext中的Products
                var products = from p in context.Products
                               select p;

                //讀取products中的項目
                foreach (var item in products)
                {
                    Console.WriteLine($"{item.ProductID}, {item.ProductName}, {item.UnitPrice}");
                }

                Console.WriteLine("請按任一鍵離開...");
                Console.ReadKey();
            }
        }
    }
}
