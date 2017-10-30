using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WellnessProject.Models;

namespace WellnessProject.Controllers
{
    public class CaloriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Calories
        public ActionResult Index()
        {
            return View(db.Calories.ToList());
        }

        // GET: Calories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calories calories = db.Calories.Find(id);
            if (calories == null)
            {
                return HttpNotFound();
            }
            return View(calories);
        }

        // GET: Calories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Goal,CurrentCalorieCount,CaloriesToAdd,MonthlyPoints,YearlyPoints,Pending")] Calories calories)
        {
            if (ModelState.IsValid)
            {
                db.Calories.Add(calories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calories);
        }

        // GET: Calories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calories calories = db.Calories.Find(id);
            if (calories == null)
            {
                return HttpNotFound();
            }
            return View(calories);
        }

        // POST: Calories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Goal,CurrentCalorieCount,CaloriesToAdd,MonthlyPoints,YearlyPoints,Pending")] Calories calories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calories);
        }

        // GET: Calories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calories calories = db.Calories.Find(id);
            if (calories == null)
            {
                return HttpNotFound();
            }
            return View(calories);
        }

        // POST: Calories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calories calories = db.Calories.Find(id);
            db.Calories.Remove(calories);
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
