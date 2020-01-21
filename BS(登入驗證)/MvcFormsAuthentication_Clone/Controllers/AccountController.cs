using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFormsAuthentication_Clone.Models;
using MvcFormsAuthentication_Clone.ViewModels;
using System.Text;
using System.Security.Cryptography;
using MvcFormsAuthentication_Clone.Services;

namespace MvcFormsAuthentication_Clone.Controllers
{
    //要做出一個登入的頁面，Login的View要做兩個，因為要回傳資料，Get+Post都要建
    public class AccountController : Controller
    {
        AccountContext db = new AccountContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]  //自己加
        [ValidateAntiForgeryToken] //自己加

        public ActionResult Login(LoginViewModel loginVM)
        {
            //未通過Model驗證就return
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            //通過Model驗證後, 將帳號及密碼進行Encode編碼(增加安全性，不用加也可)
            string name = HttpUtility.HtmlEncode(loginVM.Name);
            string password = HttpUtility.HtmlEncode(loginVM.Password); 

            //如果密碼是用MD5加密, 則用EF查詢時需以加密的字串做查詢
            string md5password = HashService.MD5Hash(password);
          
            //查詢比對後端Account資料表記錄(這邊也可以用Dapper寫)
            Account user = db.Accounts.Where(x => x.Name == name && x.Password== md5password).FirstOrDefault();

            if(user == null)
            {
                ModelState.AddModelError("", "無效的帳號或密碼");
                return View();
            }

            //談Role或其他進一步的判斷，請參考:

            //FormsAuthentication Class -- https://docs.microsoft.com/zh-tw/dotnet/api/system.web.security.formsauthentication?view=netframework-4.8

            //FormsAuthenticationTicket Class
            //https://docs.microsoft.com/zh-tw/dotnet/api/system.web.security.formsauthenticationticket?view=netframework-4.8

            //Create FormsAuthenticationTicket
            //比對後端資料庫確定找的到帳密後，核發一個憑證Ticket
            var ticket = new FormsAuthenticationTicket(
            version: 1,
            name: user.Name.ToString(), //可以放使用者Id
            issueDate: DateTime.UtcNow,//現在UTC時間
            expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
            isPersistent: true,// 是否要記住我 true or false
            userData: "", //可以放使用者角色名稱
            cookiePath: FormsAuthentication.FormsCookiePath);
            // Encrypt the ticket.
            var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密

            // Create the cookie.
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);

            // Redirect back to original URL.
            var url = FormsAuthentication.GetRedirectUrl(name, true);

            //Response.Redirect(FormsAuthentication.GetRedirectUrl(name, true));

            return Redirect(FormsAuthentication.GetRedirectUrl(name, true));
          
        }

        //登出
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

       //測試看看加密後的密碼長怎麼樣
        public ActionResult Encryption()
        {

            string password = "123456789";
            string MD5String = HashService.MD5Hash(password);
            string MD5Base64String = HashService.MD5HashBase64(password);
            string SHA1String = HashService.SHA1Hash(password);
            string SHA512String = HashService.SHA512Hash(password);

            ViewData["Password"] = password;
            ViewData["MD5"] = MD5String;
            ViewData["MD5Base64"] = MD5Base64String;
            ViewData["SHA1"] = SHA1String;
            ViewData["SHA512"] = SHA512String;

            return View();
        }


    }
}