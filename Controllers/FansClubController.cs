using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShaulisBlog.DAL;
using ShaulisBlog.Models;

namespace ShaulisBlog.Controllers
{
    public class FansClubController : Controller
    {
        private DBContext db = new DBContext();

        // GET: FansClub
        public ActionResult Index()
        {
            return View(db._Fans.ToList());
        }

        // GET: FansClub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db._Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // GET: FansClub/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FansClub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,ClubSeniority")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                db._Fans.Add(fan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fan);
        }

        // GET: FansClub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db._Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // POST: FansClub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,BirthDate,ClubSeniority")] Fan fan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fan);
        }

        // GET: FansClub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fan fan = db._Fans.Find(id);
            if (fan == null)
            {
                return HttpNotFound();
            }
            return View(fan);
        }

        // POST: FansClub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fan fan = db._Fans.Find(id);
            db._Fans.Remove(fan);
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
