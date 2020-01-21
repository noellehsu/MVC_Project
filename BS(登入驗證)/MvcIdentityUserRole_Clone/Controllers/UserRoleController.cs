using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MvcIdentityUserRole_Clone.Models;

namespace MvcIdentityUserRole_Clone.Controllers
{
    public class UserRoleController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserRoleController()
        {
        }

        public UserRoleController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }

        //老師叫我們加的(一定要先執行step1+2)
        public async Task<ActionResult> AddRole()
        {
            //後台角色名稱 
            var RoleName = "Admin";

            //判斷角色是否存在
            if (HttpContext.GetOwinContext().Get<ApplicationRoleManager>().RoleExists(RoleName) == false)
            {
                //角色不存在,建立角色
                var role = new IdentityRole(RoleName);
                await HttpContext.GetOwinContext().Get<ApplicationRoleManager>().CreateAsync(role);
            }

            return Content("The Role has created.");
        }

        //把使用者加到管理員這個角色(一定要先執行step1+2)
        public async Task<ActionResult> AddUsertoRole()
        {
            //後台角色名稱 
            var RoleName = "Admin";

            //判斷角色是否存在
            if (HttpContext.GetOwinContext().Get<ApplicationRoleManager>().RoleExists(RoleName) == false)
            {
                //角色不存在,建立角色
                var role = new IdentityRole(RoleName);
                await HttpContext.GetOwinContext().Get<ApplicationRoleManager>().CreateAsync(role);
            }

            //記得User必須先登入(否則要用EF或Dapper查詢資料庫中User的Id)
            //登入後到路由UserRole/AddUsertoRole就能成功
            //將使用者加入該角色
            await UserManager.AddToRoleAsync(User.Identity.GetUserId(), RoleName);


            return Content("The User is added to the role");
        }

        //老師叫我們加的
        public async Task<ActionResult> AddUser() //從後台註冊帳密，而非從前台
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = "jimmy@gmail.com", Email = "jimmy@gmail.com" };
                var result = await UserManager.CreateAsync(user, "Skymax.060*");
                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);


                    return Content("Success!!!");
                    //return RedirectToAction("Index", "Home");
                }

                AddErrors(result);
            }

            // 如果執行到這裡，發生某項失敗，則重新顯示表單
            return Content("Nothing");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }



    }
}