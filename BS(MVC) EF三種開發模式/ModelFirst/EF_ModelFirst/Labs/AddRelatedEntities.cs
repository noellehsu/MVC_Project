using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst
{
    public static class AddRelatedEntities
    {
        //以Entities實體物件關聯方式加入
        public static void AddEntities()
        {
            User user = new User { UserName = "Mark", Email = "mark@gmail.com" };
            Blog blog = new Blog
            {
                BlogName = "Mark's Blog",
                Url = "https://www.markblog.com",
                User = user,
                Posts = new List<Post>
                {
                    new Post { Title="Mark's Friends", Content="Mary and Tome are Mark's best friends.."},
                    new Post { Title="Mark's Home", Content="His home at Taiwan."},
                    new Post { Title="Mark's Father", Content="His Father is David."},
                }
            };

            using (var db = new BlogContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            Console.WriteLine("Entities資料新增完成,請按任意鍵離開...");
            Console.ReadKey();
        }
    }
}
