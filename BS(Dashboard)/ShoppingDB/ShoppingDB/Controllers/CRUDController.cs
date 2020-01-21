using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingDB.Models;

namespace ShoppingDB.Controllers
{
    public class CRUDController : Controller
    {
        private ShoppingContext db = new ShoppingContext();

        // GET: CRUD
        public ActionResult Index()
        {
            return View(db.Clothings.ToList());
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ModelNo,Description,Size,Category,Target,Tags,Materials,MainPhoto,Photos")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Clothings.Add(clothing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothing);
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: CRUD/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ModelNo,Description,Size,Category,Target,Tags,Materials,MainPhoto,Photos")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothing);
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            db.Clothings.Remove(clothing);
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
