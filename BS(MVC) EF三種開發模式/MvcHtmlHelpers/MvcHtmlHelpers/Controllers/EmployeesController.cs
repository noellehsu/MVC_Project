using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;
using System.Net;
using System.Data.Entity;

namespace MvcHtmlHelpers.Controllers
{
    public class EmployeesController : Controller
    {
        //初始化Entity Framework的Context環境，用來對資料庫作存取
        private CmsContext db = new CmsContext();

        public ActionResult Index()
        {
            //從資料庫讀取資料，建立model
            var emps = db.Employees.ToList();
            return View(emps);
        }

        public ActionResult Details(int? Id)
        {
            //檢查是否有員工Id的判斷
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //以Id找尋員工資料
            Employee emp = db.Employees.Find(Id);

            //如果沒有找到員工，回傳HttpNotFound
            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //通過驗證,將資料異動儲存到資料庫
                db.Employees.Add(emp);
                db.SaveChanges();
                //儲存完成後，導向Index動作法方
                return RedirectToAction("Index");
            }

            //若未通過驗證, 再次返回顯示Form表單,直到資料提交完全正確
            return View(emp);
        }

        public ActionResult Edit(int? Id)
        {
            //檢查是否有員工Id的判斷
            if (Id == null)
            {
                return Content("查無此資料, 請提供員工編號!");
            }
            //以Id找尋員工資料
            Employee emp = db.Employees.Find(Id);
            //如果沒有找到員工，回傳HttpNotFound
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Email,Department,Title")] Employee emp)
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //將emp這個Entity狀態設為Modified,
                //當SaveChanges()執行時,會向SQL Server發出Update陳述式命令
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public ActionResult Delete(int? Id)
        {
            //檢查是否有員工Id
            if (Id == null)
            {
                return Content("查無此資料, 請提供員工編號!");
            }
            //以Id找尋員工資料
            Employee emp = db.Employees.Find(Id);
            //如果沒有找到員工，回傳HttpNotFound
            if (emp == null)
            {
                return HttpNotFound();
            }

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            //以Id找尋Entity，然後刪除
            Employee emp = db.Employees.Find(Id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}