namespace CodeFirstBlog_Clone.Migrations
{
    using CodeFirstBlog_Clone.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstBlog_Clone.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstBlog_Clone.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //�إߤT��User�ؤl���
            //�p�G�ڧ�UserId1,2,3�R���A�h�إ�UserId4,5,6�A1,2,3�٬O�|�b��Ʈw�A�]���O�{Id
            context.Users.AddOrUpdate(x => x.UserId, new User { UserId = 1, UserName = "Grace_Chung", Email = "grace@gmail.com", Phone = "0938272" });
            context.Users.AddOrUpdate(x => x.UserId, new User { UserId = 2, UserName = "Machenzie_Davis  ", Email = "davis@gmail.com", Phone = "0938272" });
            context.Users.AddOrUpdate(x => x.UserId, new User { UserId = 3, UserName = "Sarah_Conner", Email = "conner@gmail.com", Phone = "0938272" });

            //�إߤT��Blog�ؤl���
            context.Blogs.AddOrUpdate(x => x.BlogId, new Blog { BlogId = 1, BlogName = "Terminator", Url = "grace.com",UserId=1});
            context.Blogs.AddOrUpdate(x => x.BlogId, new Blog { BlogId = 2, BlogName = "ToyStory", Url = "davis.com",UserId = 2 });
            context.Blogs.AddOrUpdate(x => x.BlogId, new Blog { BlogId = 3, BlogName = "Frozen", Url = "conner.com", UserId = 3 });


            //�إߤT��Blog�ؤl���
            context.Posts.AddOrUpdate(x => x.PostId, new Post { PostId = 1, Title = "Arnold says...", Content = "I'll be back.",BlogId=1});
            context.Posts.AddOrUpdate(x => x.PostId, new Post { PostId = 2, Title = "Hoodie", Content = "Hasta la vista.", BlogId = 2});
            context.Posts.AddOrUpdate(x => x.PostId, new Post { PostId = 3, Title = "Big5", Content = "conner" ,BlogId=3});



        }
    }
}
