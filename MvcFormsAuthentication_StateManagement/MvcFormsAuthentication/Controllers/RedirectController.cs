using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect
        public ActionResult Index() //當我輸入Redirect/Index會跳到Redirect/ProductList
        {
            return Redirect("ProductList");            //Http 302 臨時轉向(ex:Login)
            //return RedirectPermanent("ProductList"); //Http 301 永久轉向(ex:網站搬到新的Domain)

        }
        public ActionResult ProductList()
        {
            return View();
        }
    }
}