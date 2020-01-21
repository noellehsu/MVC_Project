namespace EF_CodeFirstNewDB.Models
{
    using System.Data.Entity;
    public partial class BlogContext : DbContext
    {
        public BlogContext(): base("BlogContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
