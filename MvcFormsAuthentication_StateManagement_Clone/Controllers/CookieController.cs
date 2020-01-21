using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication_StateManagement_Clone.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            return View();
        }

        //設定Cookies(儲存Coolies):Response.Cookies
        public ActionResult SetCookies()
        {
            Response.Cookies["Name"].Value = "Kevin";
            Response.Cookies["Email"].Value = "kevin@gmail.com";
            Response.Cookies["Mobile"].Value = "0925-259335";

            //設定逾期時間
            Response.Cookies["Name"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["Email"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies["Mobile"].Expires = DateTime.Now.AddDays(1);


            return View();
        }

        //讀取Cookies:Request.Cookies
        public ActionResult ReadCookies()
        {
            //把cookie送回給Server，所以這邊是用Request，不是Response
            string name = HttpContext.Request.Cookies["Name"].Value;
            string email = HttpContext.Request.Cookies["Email"].Value;
            string mobile = HttpContext.Request.Cookies["Mobile"].Value;

            return View();
        }

    }
}