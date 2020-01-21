using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporting()
        {
            if (Session["LoginStatus"] == null || (bool)Session["LoginStatus"] != true)
            {
                return Redirect("~/Account/Login");
            }

            return View();
        }
    }
}