using System;
using System.Linq;
using EF_CodeFirstNewDB.Models;

namespace EF_CodeFirstNewDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogContext())    //初始化DbContext類別實例
            {
                //新增Entity
                //context.Users就是DbSet<User>
                if (!context.Users.Any()) //檢查DbSet<User>是否存在任何實體資料
                {
                    //新增Entity
                    User user = new User { UserName = "聖殿祭司", Email = "dotnetcool@gmail.com" };
                    context.Users.Add(user);    //將Entity加入DbSet<User>
                    context.SaveChanges();      //儲存異動, 將資料寫入資料庫
                }
                

                //讀取資料
                foreach(var item in context.Users)
                {
                    Console.WriteLine($"Name : {item.UserName}, Email : {item.Email}");
                }

                Console.WriteLine("請按任一鍵離開...");
                Console.ReadKey();
            }
        }
    }
}
