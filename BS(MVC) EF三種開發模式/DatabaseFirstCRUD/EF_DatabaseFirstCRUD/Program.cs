using System;
using System.Linq;

namespace EF_DatabaseFirstCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadData();
            //UpdateData();
            //CreateData();
            //DeleteData();
        }

        //查詢資料
        static void ReadData()
        {
            using (var db = new NorthwindContext())
            {
                var products = from p in db.Products
                               where p.UnitPrice >= 30 && p.UnitPrice <= 40
                               orderby p.ProductName descending, p.UnitPrice ascending, p.UnitsInStock
                               select new { p.ProductID, p.ProductName, p.UnitPrice, p.UnitsInStock };

                var total = products.Count();   //計算總筆數
                int i = 1;

                Console.WriteLine($"價格介於20-40元的產品共有{total}件,清單如下:");
                Console.WriteLine("項目編號: 產品ID, 產品名稱, 單價, 庫存=======");

                foreach (var p in products)
                {
                    Console.WriteLine($"{i++.ToString("00")}: {p.ProductID}, {p.ProductName}, {p.UnitPrice}, {p.UnitsInStock}");
                }
            }

            Console.WriteLine("請按任意鍵離開...");
            Console.ReadKey();
        }

        //可一次更新多筆Entity資料
        static void UpdateData()
        {
            using (var db = new NorthwindContext())
            {
                //以Find(id)找尋資Entity
                var p1 = db.Products.Find(64);
                p1.UnitsInStock = 13;

                //以字串找尋Entity
                var p2 = db.Products.FirstOrDefault(p => p.ProductName.Contains("Alice Mutton"));
                p2.UnitPrice = 39;

                //儲存變更
                db.SaveChanges();
            }
        }

        //可一次新增多筆Entity資料
        static void CreateData()
        {
            using (var db = new NorthwindContext())
            {
                //新增一筆Product Entity
                Product p1 = new Product { ProductName = "Car", UnitPrice = 100000, UnitsInStock = 1, UnitsOnOrder = 10 };
                //用Add()方法將Entity加入到Products
                db.Products.Add(p1);

                //直接將Entity加入到Add()方法中
                db.Products.Add(new Product { ProductName = "iPhone", UnitPrice = 799, UnitsInStock = 100, UnitsOnOrder = 300 });
                db.SaveChanges();
            }
        }

        //可一次刪除多筆Entity資料
        static void DeleteData()
        {
            using (var db = new NorthwindContext())
            {
                //用id找尋Entity
                var p1 = db.Products.Find(80);
                //在FirstOrDefault()方法中用ProductName尋找
                var p2 = db.Products.FirstOrDefault(p => p.ProductName == "iPhone");

                if (p1 == null && p2 == null)
                {
                    Console.WriteLine("找不到符合資料, 未執行任何刪除動作");
                }

                if (p1 != null)
                {
                    db.Products.Remove(p1);
                }

                if (p2 != null)
                {
                    db.Products.Remove(p2);
                }

                //儲存變更
                db.SaveChanges();

                Console.WriteLine("已完成刪除");
            }
        }

        static void ReadSimple()
        {
            //查詢所有資料
            using (var db = new NorthwindContext())
            {
                var products = from p in db.Products
                               select p;

                Console.WriteLine("Products產品資訊如下:");
                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductID + ":" + item.ProductName + "," + item.UnitPrice);
                }
            }

            Console.WriteLine("請按任意鍵離開...");
            Console.ReadKey();
        }

        static void UpdateSimple()
        {
            using (var db = new NorthwindContext())
            {
                //以find(id)找尋資Entity
                var p = db.Products.Find(64);
                p.UnitsInStock = 13;

                //儲存變更
                db.SaveChanges();
            }
        }

        static void CreateSimple()
        {
            using (var db = new NorthwindContext())
            {
                //新增一筆Product Entity
                Product p = new Product { ProductName = "Car", UnitPrice = 100000, UnitsInStock = 1, UnitsOnOrder = 10 };
                //用Add()方法將Entity加入到Products
                db.Products.Add(p);
                //呼叫SaveChanges()儲存變更時,新增至資料庫
                db.SaveChanges();
            }
        }

        static void DeleteSimple()
        {
            using (var db = new NorthwindContext())
            {
                //用id找尋Entity
                var p = db.Products.Find(10);
                //用Remove()將Entity標記為刪除,
                db.Products.Remove(p);
                //:呼叫SaveChanges()儲存變更時,自資料庫中刪除
                db.SaveChanges();
            }
        }
        static void QuerySingleData()
        {
            var db = new NorthwindContext();

            //如果Entity有Primary Key的話,可用Find()方法查詢
            var p1 = db.Products.Find(13);

            //Sinle()或SingleOrDefault()適合用Unique Key做查詢,回傳單一筆
            var p2 = db.Products.Single(p => p.ProductID == 3);

            //First()或FirstOrDefault(),若有多筆則回傳第一筆
            var p3 = db.Products.FirstOrDefault(p => p.ProductName == "Ikura");

            Console.WriteLine(p1.ProductID + "," + p1.ProductName);
            Console.WriteLine(p2.ProductID + "," + p2.ProductName);
            Console.WriteLine(p3.ProductID + "," + p3.ProductName);

            Console.WriteLine("請按任意鍵離開...");
            Console.ReadKey();

            db.Dispose();   //釋放佔用資源和資料庫連線

            //說明:
            //1.Single()和SingleOrDefault()查詢結果若有多筆,則會執出例外System.InvalidOperationException: 'Sequence contains more than one element'
            //2.Single()和First()方法若找不到資料會擲出System.InvalidOperationException: 'Sequence contains no elements'
            //3.SingleOrDefault()和FirstOrDefault()若找不到資料會回傳null
            //4.Single(),SingleOrDefault(),First(),FirstOrDefault()四個指令皆為即時查詢
        }

    }
}
