namespace MvcRepostitory.Migrations
{
    using MvcRepostitory.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcRepostitory.Models.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcRepostitory.Models.CmsContext context)
        {
            /*AddOrUpdate()��k�O�ΨӰ��˥���ƪ��s�W�Χ�s�A��k���Ĥ@�ӰѼ�X => X.UserId �O����諸Key�ȡA
            �ĤG�ӰѼ�new Employee�O�s�W��Entity ���*/
            context.Employees.AddOrUpdate(
                x => x.Id,
                new Employee { Id = 1, Name = "David", Mobile = "0933-152667", Email = "david@gmail.com", Department = "�`�g�z��", Title = "CEO" },
                new Employee { Id = 2, Name = "Mary", Mobile = "0938-456889", Email = "mary@gmail.com", Department = "�H�Ƴ�", Title = "�޲z�v" },
                new Employee { Id = 3, Name = "Joe", Mobile = "0925-331225", Email = "joe@gmail.com", Department = "�]�ȳ�", Title = "�g�z" },
                new Employee { Id = 4, Name = "Mark", Mobile = "0935-863991", Email = "mark@gmail.com", Department = "�~�ȳ�", Title = "�~�ȭ�" },
                new Employee { Id = 5, Name = "Rose", Mobile = "0987-335668", Email = "rose@gmail.com", Department = "��T��", Title = "�u�{�v" }
                );

            context.Registers.AddOrUpdate(
                x => x.Id,
                new Register { Id = 1, Name = "�O����", Nickname = "�t�����q", Password = "myPassword*", Email = "dotnetcool@gmail.com", City = 4, Gender = 1, Commutermode = "1", Comment = "Nothing", Terms = true }
                );
        }
    }
}
