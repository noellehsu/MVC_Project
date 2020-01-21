namespace Mvc_CodeFirstCRUD.Models
{
    using System.Data.Entity;
    public partial class BlogContext : DbContext
    {
        public BlogContext(): base("BlogConnection")
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
