
namespace CodeFirstBlog_Clone.Models
{
    using System.Data.Entity;
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogConnection") //指定Web.config中的資料庫連線
        { 

        }

        //三個Entity Sets
        //一個DbSet 中包含許多Entity實體資料
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}