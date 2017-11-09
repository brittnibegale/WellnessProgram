using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.Controllers
{
    public class ExerciseAlertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseAlerts
        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).ToString();
            var captainGroupString = db.Customers.Where(m => m.ApplicationUserId == currentUser).Select(m => m.GroupId).ToString();
            var captainGroupId = Int32.Parse(captainGroupString);
            var exerciseAlerts = db.ExerciseAlerts.Where(m => m.Group == captainGroupId && m.Read == false).Include(e => e.Customer);

            return View(exerciseAlerts.ToList());
        }

        // GET: ExerciseAlerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseAlert exerciseAlert = db.ExerciseAlerts.Find(id);
            if (exerciseAlert == null)
            {
                return HttpNotFound();
            }
            return View(exerciseAlert);
        }

        // GET: ExerciseAlerts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: ExerciseAlerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VigorousGoal,ModerateGoal,currentVigorous,currentModerate,CustomerFirstName,CustomerLastName,Read,CustomerId")] ExerciseAlert exerciseAlert)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseAlerts.Add(exerciseAlert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", exerciseAlert.CustomerId);
            return View(exerciseAlert);
        }

        // GET: ExerciseAlerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseAlert exerciseAlert = db.ExerciseAlerts.Find(id);
            if (exerciseAlert == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", exerciseAlert.CustomerId);
            return View(exerciseAlert);
        }

        // POST: ExerciseAlerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VigorousGoal,ModerateGoal,currentVigorous,currentModerate,CustomerFirstName,CustomerLastName,Read,CustomerId")] ExerciseAlert exerciseAlert)
        {
            if (ModelState.IsValid)
            {
                if (exerciseAlert.Read == true)
                {
                    var customer = exerciseAlert.Customer;
                    customer.ExerciseMonthlyPoints += 1;
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                db.Entry(exerciseAlert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", exerciseAlert.CustomerId);
            return View(exerciseAlert);
        }

        // GET: ExerciseAlerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseAlert exerciseAlert = db.ExerciseAlerts.Find(id);
            if (exerciseAlert == null)
            {
                return HttpNotFound();
            }
            return View(exerciseAlert);
        }

        // POST: ExerciseAlerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseAlert exerciseAlert = db.ExerciseAlerts.Find(id);
            db.ExerciseAlerts.Remove(exerciseAlert);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DenyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseAlert exerciseAlert = db.ExerciseAlerts.Find(id);
            if (exerciseAlert == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", exerciseAlert.CustomerId);
            return View(exerciseAlert);
        }

        [HttpPost]
        public ActionResult DenyEdit(ExerciseAlert exerciseAlert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseAlert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exerciseAlert);
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
