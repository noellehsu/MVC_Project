namespace MvcFormsAuthentication_Clone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcFormsAuthentication_Clone;
    using MvcFormsAuthentication_Clone.Models;
    using MvcFormsAuthentication_Clone.Services;


    internal sealed class Configuration : DbMigrationsConfiguration<AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccountContext context)
        { //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" }
            //    );
            

            //§â±K½X¥[±K
            context.Accounts.AddOrUpdate(
                x=>x.Id,
                new Account { Id = 1, Name = "Kevin", Password = HashService.MD5Hash("87654321"), Email = "kevin@gmail.com", Mobile = "0925-155-286" },
                new Account { Id = 2, Name = "Mary", Password = HashService.MD5Hash("12345678"), Email = "Mary@gmail.com", Mobile = "0933-559-828" },
                new Account { Id=3,Name="Noelle",Password= HashService.MD5Hash("88999111"),Email="No@gmail.com",Mobile="0911-111-111"},
                new Account { Id = 3, Name = "Joe", Password = HashService.MD5Hash("abc12345"), Email = "jog@gmail.com", Mobile = "0925-155-286" }

                );


        }
    }
}
