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
    public class HealthInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HealthInfoes
        public ActionResult Index()
        {
            return View(db.HealthInfos.ToList());
        }

        // GET: HealthInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthInfo healthInfo = db.HealthInfos.Find(id);
            if (healthInfo == null)
            {
                return HttpNotFound();
            }
            return View(healthInfo);
        }

        // GET: HealthInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UniqueCode,Age,Gender,Height,Weight,Smoker,BodyFatAmt,Hdl,Ldl,CholesterolTotal,Triglycerides")] HealthInfo healthInfo)
        {
            if (ModelState.IsValid)
            {
                db.HealthInfos.Add(healthInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthInfo);
        }

        // GET: HealthInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthInfo healthInfo = db.HealthInfos.Find(id);
            if (healthInfo == null)
            {
                return HttpNotFound();
            }
            return View(healthInfo);
        }

        // POST: HealthInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UniqueCode,Age,Gender,Height,Weight,Smoker,BodyFatAmt,Hdl,Ldl,CholesterolTotal,Triglycerides")] HealthInfo healthInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthInfo);
        }

        // GET: HealthInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthInfo healthInfo = db.HealthInfos.Find(id);
            if (healthInfo == null)
            {
                return HttpNotFound();
            }
            return View(healthInfo);
        }

        // POST: HealthInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthInfo healthInfo = db.HealthInfos.Find(id);
            db.HealthInfos.Remove(healthInfo);
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
