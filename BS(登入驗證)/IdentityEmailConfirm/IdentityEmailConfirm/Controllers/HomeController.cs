using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace IdentityEmailConfirm.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("dotnetcool@gmail.com", "skymax.069*#$")
            };
            //smtp.Credentials = new System.Net.NetworkCredential("dotnetcool@gmail.com", "skymax.069*#$");
            //smtp.EnableSsl = true;

            smtp.Send("dotnetcool@gmail.com", "dotnetcool@gmail.com", "Service Mail Test", "Mail Body");

            return new EmptyResult();
        }
    }
}