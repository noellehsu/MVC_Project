using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication_Clone.Controllers
{
    //[Authorize] 砍掉，直接在Web.config加上authorization屬性，套用到整個網站

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}