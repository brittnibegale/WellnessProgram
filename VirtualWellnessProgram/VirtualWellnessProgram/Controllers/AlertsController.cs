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
using VirtualWellnessProgram.Models.ViewModels;

namespace VirtualWellnessProgram.Controllers
{
    public class AlertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alerts
        public ActionResult Index()
        {
            var alerts = db.Alerts.Where(m => m.Read == false).Include(a => a.Customer);
            return View(alerts.ToList());
        }

        // GET: Alerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // GET: Alerts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Alerts,Read,CustomerId")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                alert.Read = false;
                var username = User.Identity.Name;
                var currentUserId = db.Users.Where(m => m.UserName == username).Select(m => m.Id).First();
                var currentCustomerIdString = db.Customers.Where(m => m.ApplicationUserId == currentUserId).Select(m => m.Id).ToString();
                int currentCustomerId = Int32.Parse(currentCustomerIdString);
                alert.CustomerId = currentCustomerId;
                db.Alerts.Add(alert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", alert.CustomerId);
            return View(alert);
        }

        // GET: Alerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            AlertEditViewModel viewModel = new AlertEditViewModel();
            viewModel.Alert = alert;
            
            return View(viewModel);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlertEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var response = viewModel.Response.Trim().ToLower();
                if (response == "none")
                {
                    db.Entry(viewModel.Alert).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    var groupId = db.Groups.Where(m => m.GroupName == response).Select(n => n.Id).First();
                    var customer = db.Customers.Where(m => m.Id == viewModel.Alert.CustomerId).First();
                    customer.GroupId = groupId;

                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();

                    db.Entry(viewModel.Alert).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        // GET: Alerts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return HttpNotFound();
            }
            return View(alert);
        }

        // POST: Alerts/Delete/5
        [Audit]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alert alert = db.Alerts.Find(id);
            db.Alerts.Remove(alert);
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
