using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DashboardChart.Models;

namespace DashboardChart.Controllers
{
    public class CRUDController : Controller
    {
        private DashboardChartContext db = new DashboardChartContext();

        // GET: CRUD
        public async Task<ActionResult> Index()
        {
            return View(await db.Clothings.ToListAsync());
        }

        // GET: CRUD/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = await db.Clothings.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ClothingId,Size,Description,UnitInStock")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Clothings.Add(clothing);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clothing);
        }

        // GET: CRUD/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = await db.Clothings.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ClothingId,Size,Description,UnitInStock")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothing).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clothing);
        }

        // GET: CRUD/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = await db.Clothings.FindAsync(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Clothing clothing = await db.Clothings.FindAsync(id);
            db.Clothings.Remove(clothing);
            await db.SaveChangesAsync();
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
