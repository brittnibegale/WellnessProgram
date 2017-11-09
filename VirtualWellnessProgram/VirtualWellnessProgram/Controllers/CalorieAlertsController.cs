using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualWellnessProgram.Audit;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.Controllers
{
    public class CalorieAlertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CalorieAlerts
        public ActionResult Index()
        {
            var calorieAlerts = db.CalorieAlerts.Include(c => c.customer);
            return View(calorieAlerts.ToList());
        }

        // GET: CalorieAlerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieAlert calorieAlert = db.CalorieAlerts.Find(id);
            if (calorieAlert == null)
            {
                return HttpNotFound();
            }
            return View(calorieAlert);
        }

        // GET: CalorieAlerts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: CalorieAlerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CalorieGoal,CaloriesConsumed,CustomerFirstName,CustomerLastName,Read,CustomerId")] CalorieAlert calorieAlert)
        {
            if (ModelState.IsValid)
            {
                db.CalorieAlerts.Add(calorieAlert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", calorieAlert.CustomerId);
            return View(calorieAlert);
        }

        // GET: CalorieAlerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieAlert calorieAlert = db.CalorieAlerts.Find(id);
            if (calorieAlert == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", calorieAlert.CustomerId);
            return View(calorieAlert);
        }

        // POST: CalorieAlerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CalorieGoal,CaloriesConsumed,CustomerFirstName,CustomerLastName,Read,CustomerId")] CalorieAlert calorieAlert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calorieAlert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", calorieAlert.CustomerId);
            return View(calorieAlert);
        }

        // GET: CalorieAlerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalorieAlert calorieAlert = db.CalorieAlerts.Find(id);
            if (calorieAlert == null)
            {
                return HttpNotFound();
            }
            return View(calorieAlert);
        }

        // POST: CalorieAlerts/Delete/5
        [Audit]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalorieAlert calorieAlert = db.CalorieAlerts.Find(id);
            db.CalorieAlerts.Remove(calorieAlert);
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
