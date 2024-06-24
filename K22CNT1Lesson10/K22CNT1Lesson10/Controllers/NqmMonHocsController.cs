using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT1Lesson10.Models;

namespace K22CNT1Lesson10.Controllers
{
    public class NqmMonHocsController : Controller
    {
        private NqmK22CNTT1DZEntities db = new NqmK22CNTT1DZEntities();

        // GET: NqmMonHocs
        public ActionResult NqmIndex()
        {
            return View(db.MonHoc.ToList());
        }

        // GET: NqmMonHocs/Details/5
        public ActionResult NqmDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHoc.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: NqmMonHocs/Create
        public ActionResult NqmCreate()
        {
            return View();
        }

        // POST: NqmMonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NqmCreate([Bind(Include = "MaMH,TenMH,Sotiet")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHoc.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("NqmIndex");
            }

            return View(monHoc);
        }

        // GET: NqmMonHocs/Edit/5
        public ActionResult NqmEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHoc.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: NqmMonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NqmEdit([Bind(Include = "MaMH,TenMH,Sotiet")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NqmIndex");
            }
            return View(monHoc);
        }

        // GET: NqmMonHocs/Delete/5
        public ActionResult NqmDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHoc.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: NqmMonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult NqmDeleteConfirmed(string id)
        {
            MonHoc monHoc = db.MonHoc.Find(id);
            db.MonHoc.Remove(monHoc);
            db.SaveChanges();
            return RedirectToAction("NqmIndex");
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
