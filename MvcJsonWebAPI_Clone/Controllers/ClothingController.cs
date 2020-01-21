using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcJsonWebAPI_Clone.Models;

namespace MvcJsonWebAPI_Clone.Controllers
{
    public class ClothingController : Controller
    {
        Clothing clothing = new Clothing()
        {
            Id=43460051,
            Name="Fleece高領上衣-女",
            Price=168,
            MainPhoto="4346005_500.jpg",
            Photos=new string[] { 
                "43460_D_21_0.jpg", 
                "43460_D_23_0.jpg", 
                "43460_D_24SP.jpg", 
                "43460_D_25SP.jpg", 
                "43460_D_26SP.jpg", 
                "43460_D_57SP.jpg" }

        };


        // GET: Clothing
        public ActionResult Index()
        {
            return View(clothing);
        }
    }
}