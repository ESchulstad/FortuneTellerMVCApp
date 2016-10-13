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
    public class CustomersController : Controller
    {
        private FortuneTellerEntities db = new FortuneTellerEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Color).Include(c => c.Month).Include(c => c.Sibling);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);

            string favColor = customer.Color.Name;
            string birthMonth = customer.Month.MonthName;
            string numOfSiblings = customer.Sibling.SiblingCount;
            int age = customer.CustomerAge;

            if (customer == null)
            {
                return HttpNotFound();
            }

            if(age%2==0)
            {
                ViewBag.Retirement = "40";
            }
            else
            {
                ViewBag.Retirement = "25";
            }

            if(numOfSiblings=="0")
            {
                ViewBag.vacaHome = "the Bahamas";
            }
            else if(numOfSiblings == "1")
            {
                ViewBag.vacaHome = "Bora Bora";
            }

            else if (numOfSiblings == "2")
            {
                ViewBag.vacaHome = "Southern France";
            }
            else if (numOfSiblings == "3")
            {
                ViewBag.vacaHome = "Italy";
            }
            else if (numOfSiblings == "4 or more")
            {
                ViewBag.vacaHome = "Maui";
            }

            if (birthMonth == "January" || birthMonth=="February" || birthMonth== "March" || birthMonth=="April")
            {
                ViewBag.Money = "$1,400,000,000";
            }
            else if(birthMonth == "May" || birthMonth == "June" || birthMonth == "July" || birthMonth == "August")
            {
                ViewBag.Money = "$500,800,000";
            }

            else if (birthMonth == "September" || birthMonth == "October" || birthMonth == "November" || birthMonth == "December")
            {
                ViewBag.Money = "$900,120,000";
            }


            if (favColor == "Red")
            {
                ViewBag.TransportationMode = "sports car";
            }
            else if (favColor == "Orange")
            {
                ViewBag.TransportationMode = "private jet";
            }
            else if (favColor == "Yellow")
            {
                ViewBag.TransportationMode = "hot air balloon";
            }
            else if (favColor == "Green")
            {
                ViewBag.TransportationMode = "mini-van";
            }
            else if (favColor == "Blue")
            {
                ViewBag.TransportationMode = "submarine";
            }
            else if (favColor == "Indigo")
            {
                ViewBag.TransportationMode = "yacht";
            }
            else if (favColor == "Violet")
            {
                ViewBag.TransportationMode = "bicycle";
            }

           

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CustomerColor = new SelectList(db.Colors, "ColorID", "Name");
            ViewBag.CustomerBirthMonth = new SelectList(db.Months, "MonthID", "MonthName");
            ViewBag.CustomerSiblings = new SelectList(db.Siblings, "SibilingID", "SiblingCount");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName,CustomerAge,CustomerBirthMonth,CustomerColor,CustomerSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerColor = new SelectList(db.Colors, "ColorID", "Name", customer.CustomerColor);
            ViewBag.CustomerBirthMonth = new SelectList(db.Months, "MonthID", "MonthName", customer.CustomerBirthMonth);
            ViewBag.CustomerSiblings = new SelectList(db.Siblings, "SibilingID", "SiblingCount", customer.CustomerSiblings);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerColor = new SelectList(db.Colors, "ColorID", "Name", customer.CustomerColor);
            ViewBag.CustomerBirthMonth = new SelectList(db.Months, "MonthID", "MonthName", customer.CustomerBirthMonth);
            ViewBag.CustomerSiblings = new SelectList(db.Siblings, "SibilingID", "SiblingCount", customer.CustomerSiblings);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,CustomerFirstName,CustomerLastName,CustomerAge,CustomerBirthMonth,CustomerColor,CustomerSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerColor = new SelectList(db.Colors, "ColorID", "Name", customer.CustomerColor);
            ViewBag.CustomerBirthMonth = new SelectList(db.Months, "MonthID", "MonthName", customer.CustomerBirthMonth);
            ViewBag.CustomerSiblings = new SelectList(db.Siblings, "SibilingID", "SiblingCount", customer.CustomerSiblings);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
