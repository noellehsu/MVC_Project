namespace MvcFormsAuthentication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MvcFormsAuthentication.Models;
    using MvcFormsAuthentication.Services;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcFormsAuthentication.Models.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcFormsAuthentication.Models.AccountContext context)
        {
            context.Accounts.AddOrUpdate(
                x => x.Id,
                new Account { Id = 1, Name = "Kevin", Password = "12345678", Email = "kevin@gmail.com", Mobile = "0925-155-286" },
                new Account { Id = 2, Name = "Mary", Password = "12345678", Email = "Mary@gmail.com", Mobile = "0933-559-828" }

                //new Account { Id = 1, Name = "Kevin", Password = HashService.MD5Hash("123456789"), Email = "kevin@gmail.com", Mobile = "0925-155-286" }
            );
        }
    }
}
