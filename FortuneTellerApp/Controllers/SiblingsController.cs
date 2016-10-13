using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerApp.Models;

namespace FortuneTellerApp.Controllers
{
    public class SiblingsController : Controller
    {
        private FortuneTellerEntities db = new FortuneTellerEntities();

        // GET: Siblings
        public ActionResult Index()
        {
            return View(db.Siblings.ToList());
        }

        // GET: Siblings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sibling sibling = db.Siblings.Find(id);
            if (sibling == null)
            {
                return HttpNotFound();
            }
            return View(sibling);
        }

        // GET: Siblings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Siblings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SibilingID,SiblingCount")] Sibling sibling)
        {
            if (ModelState.IsValid)
            {
                db.Siblings.Add(sibling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sibling);
        }

        // GET: Siblings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sibling sibling = db.Siblings.Find(id);
            if (sibling == null)
            {
                return HttpNotFound();
            }
            return View(sibling);
        }

        // POST: Siblings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SibilingID,SiblingCount")] Sibling sibling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sibling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sibling);
        }

        // GET: Siblings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sibling sibling = db.Siblings.Find(id);
            if (sibling == null)
            {
                return HttpNotFound();
            }
            return View(sibling);
        }

        // POST: Siblings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sibling sibling = db.Siblings.Find(id);
            db.Siblings.Remove(sibling);
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
