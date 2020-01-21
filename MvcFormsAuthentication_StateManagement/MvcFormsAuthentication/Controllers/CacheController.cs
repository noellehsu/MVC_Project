using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFormsAuthentication.Controllers
{
    public class CacheController : Controller
    {
        // GET: Cache
        [OutputCache(Duration =60)]
        public ActionResult Index()
        {
            return View();
        }
    }
}