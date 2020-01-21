using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;
using System.ComponentModel.DataAnnotations;
using MvcHtmlHelpers.Helpers;

namespace MvcHtmlHelpers.Controllers
{
    public class ProfileController : Controller
    {
        //純粹的HTML語法
        [HttpGet]
        public ActionResult CreateHtml()
        {
            return View();
        }

        //Form表單提交的資料, 以FormCollection為傳入參數
        [HttpPost]
        public ActionResult CreateHtml(FormCollection fc)
        {
            //方式1:一一讀取資料值,再一一指定給TempData,然後傳送給View顯示
            //讀取Form提交的資料值
            string name = fc["name"];
            string password = fc["password"];
            string email = fc["email"];
            string city = fc["city"];
            string gender = fc["gender"];
            string commutermode = fc["commutermode"];
            string comment = fc["comment"];
            string terms = fc["comment"];

            //方式2:將每一個值儲存到TempData, 然後傳送給View顯示
            TempData["Name"] = name;
            TempData["Password"] = password;
            TempData["Email"] = email;
            TempData["City"] = city;
            TempData["Gender"] = gender;
            TempData["Commutermode"] = commutermode;
            TempData["Comment"] = comment;
            TempData["Terms"] = terms;

            //方式3:將整個FormCollection保存在TempData中, 然後傳送給View顯示
            TempData["UserData"] = fc;

            //RedirectToAction()方法會導向ShowUserData.chhtml檢視
            return RedirectToAction("ShowUserData");
        }

        //使用HTML + Boostrap
        public ActionResult CreateBootstrap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBootstrap(FormCollection fc)
        {
            //將整個FormCollection保存在TempData中, 然後傳送給View顯示
            TempData["UserData"] = fc;

            //RedirectToAction()方法會導向ShowUserData.chhtml檢視
            return RedirectToAction("ShowUserData");
        }


        //使用MVC HTML Helpers
        public ActionResult CreateHtmlHelper()
        {            
            //將CityList & GenderList指派給ViewBag.Cities, 傳送給View
            //ViewBag.Cities = Utility.getCityList();
            //ViewBag.Gender = Utility.getGenderList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHtmlHelper(FormCollection fc)
        {
            //將CityList & GenderList指派給ViewBag.Cities, 傳送給View
            //ViewBag.Cities = Utility.getCityList();
            //ViewBag.Gender = Utility.getGenderList();

            //將整個FormCollection保存在TempData中, 然後傳送給View顯示
            TempData["Data"] = fc;

            return View("ShowFormCollection");
            //return View("~/Views/Shared/ShowFormCollection.cshtml");
        }

        public ActionResult ShowUserData()
        {
            return View();
        }

        /*
        public ActionResult RegisterAccount()
        {
            return View();
        }


        //Form表單提交的資料, 以Model為傳入參數
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAccount(Register register)
        {
            if (ModelState.IsValid)
            {
                //Todo:...
            }

            return View(register);
        }
        */
    }
}