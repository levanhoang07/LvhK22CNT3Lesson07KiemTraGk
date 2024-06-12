using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LvhBaiKiemTraGK.Models;

namespace LvhBaiKiemTraGK.Controllers
{
    public class LvhKhoasController : Controller
    {
        private LvhK22CNT3Lesson07DbEntities db = new LvhK22CNT3Lesson07DbEntities();

        // GET: LvhKhoas
        public ActionResult LvhIndex()
        {
            // Fetch all Khoas from the database and pass them to the view
            return View(db.LvhKhoas.ToList());
        }

        // GET: LvhKhoas/Details/5
        public ActionResult LvhDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Create
        public ActionResult LvhCreate()
        {
            return View();
        }

        // POST: LvhKhoas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhCreate([Bind(Include = "LvhMaKH,LvhTenKh,LvhTrangThai")] LvhKhoa lvhKhoa)
        {
            if (ModelState.IsValid)
            {
                // Add the new Khoa to the database
                db.LvhKhoas.Add(lvhKhoa);
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }

            // If ModelState is not valid, return to the create view with the model to display validation errors
            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Edit/5
        public ActionResult LvhEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // POST: LvhKhoas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LvhEdit([Bind(Include = "LvhMaKH,LvhTenKh,LvhTrangThai")] LvhKhoa lvhKhoa)
        {
            if (ModelState.IsValid)
            {
                // Update the Khoa in the database
                db.Entry(lvhKhoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LvhIndex");
            }
            return View(lvhKhoa);
        }

        // GET: LvhKhoas/Delete/5
        public ActionResult LvhDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            if (lvhKhoa == null)
            {
                return HttpNotFound();
            }
            return View(lvhKhoa);
        }

        // POST: LvhKhoas/Delete/5
        [HttpPost, ActionName("LvhDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LvhDeleteConfirmed(string id)
        {
            LvhKhoa lvhKhoa = db.LvhKhoas.Find(id);
            db.LvhKhoas.Remove(lvhKhoa);
            db.SaveChanges();
            return RedirectToAction("LvhIndex");
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
