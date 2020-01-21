using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            
             Response.Cookies["Name"].Value = "Kevin";
             Response.Cookies["Name"].Expires = DateTime.Now.AddDays(1);

             Response.Cookies["Email"].Value = "kevin@gmail.com";
             Response.Cookies["Email"].Expires = DateTime.Now.AddDays(1);

             Response.Cookies["Mobile"].Value = "0925-259335";
             Response.Cookies["Mobile"].Expires = DateTime.Now.AddDays(1);

            return View();
        }

        public ActionResult ReadCookie()
        {
            string name = HttpContext.Request.Cookies["Name"].Value;
            string email = HttpContext.Request.Cookies["Email"].Value;
            string mobile = HttpContext.Request.Cookies["Mobile"].Value;

            return View();
        }
    }
}