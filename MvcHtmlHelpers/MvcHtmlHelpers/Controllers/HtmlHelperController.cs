using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;

namespace MvcHtmlHelpers.Controllers
{
    public class HtmlHelperController : Controller
    {
        public ActionResult SampleHelpers()
        {
            User register = new User
            {
                Id = 1001,
                Name = "奚江華",
                Nickname = "聖殿祭司",
                Email = "kevin@gmail.com",
                City = 2,
                Terms = true
            };

            ViewData.Model = register;

            return View();
        }

        // GET: HtmlHelper
        public ActionResult CommonHelpers()
        {
            Register register = new Register();
            register.Email = "dotnetcool@gmail.com";
            ViewData.Model = register;

            return View();
        }

        public ActionResult EditorFor()
        {
            RegisterDataAnnotations register = new RegisterDataAnnotations
            {
                Id = 1,
                Name = "聖殿祭司",
                Password = "myPassword",
                Email = "kevin@gmail.com",
                HomePage = "http://blog.sina.com.tw",
                Gender = Gender.Male,
                Birthday = new DateTime(1980, 6, 16),
                Birthday2 = new DateTime(1980, 6, 16),
                City = 4,
                Commutermode = "1",
                Comment = "請留下您的意見",
                Terms = true
            };

            return View(register);
        }

        [HttpGet]
        public ActionResult ValidationMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidationMessage(User user)
        {
            if (ModelState.IsValid)
            {
                return Content("成功!");
            }

            return View(user);
        }

        public ActionResult HelpersBootstrap()
        {
            Register register = new Register
            {
                Id = 1,
                Name = "Kevin",
                Email = "kevin@gmail.com"
            };

            return View(register);
        }
    }
}