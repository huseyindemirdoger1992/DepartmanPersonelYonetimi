using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepartmanPersonelYonetimi.Models;

namespace DepartmanPersonelYonetimi.Controllers
{
    public class PersonelsController : Controller
    {
        private AppConnectionDbString db = new AppConnectionDbString();

        // GET: Personels
        public ActionResult Index()
        {
            var personel = db.Personel.Include(p => p.Departman);
            return View(personel.ToList());
        }

        // GET: Personels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        public ActionResult Create()
        {
            ViewBag.DepartmanId = new SelectList(db.Departman, "DepartmanId", "DepartmanAd");
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelId,PersonelAd,PersonelSoyad,DepartmanId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmanId = new SelectList(db.Departman, "DepartmanId", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmanId = new SelectList(db.Departman, "DepartmanId", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelId,PersonelAd,PersonelSoyad,DepartmanId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmanId = new SelectList(db.Departman, "DepartmanId", "DepartmanAd", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
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
