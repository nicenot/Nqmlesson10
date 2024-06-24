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
    public class NqmDiemsController : Controller
    {
        private NqmK22CNTT1DZEntities db = new NqmK22CNTT1DZEntities();

        // GET: NqmDiems
        public ActionResult NqmIndex()
        {
            var diem = db.Diem.Include(d => d.MonHoc).Include(d => d.SinhVien);
            return View(diem.ToList());
        }

        // GET: NqmDiems/Details/5
        public ActionResult NqmDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diem.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: NqmDiems/Create
        public ActionResult NqmCreate()
        {
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH");
            ViewBag.MaSV = new SelectList(db.SinhVien, "MaSV", "HoSV");
            return View();
        }

        // POST: NqmDiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NqmCreate([Bind(Include = "MaSV,MaMH,Diem1")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diem.Add(diem);
                db.SaveChanges();
                return RedirectToAction("NqmIndex");
            }

            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhVien, "MaSV", "HoSV", diem.MaSV);
            return View(diem);
        }

        // GET: NqmDiems/Edit/5
        public ActionResult NqmEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diem.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhVien, "MaSV", "HoSV", diem.MaSV);
            return View(diem);
        }

        // POST: NqmDiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NqmEdit([Bind(Include = "MaSV,MaMH,Diem1")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NqmIndex");
            }
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", diem.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhVien, "MaSV", "HoSV", diem.MaSV);
            return View(diem);
        }

        // GET: NqmDiems/Delete/5
        public ActionResult NqmDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diem.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: NqmDiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult NqmDeleteConfirmed(string id)
        {
            Diem diem = db.Diem.Find(id);
            db.Diem.Remove(diem);
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
