using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualWellnessProgram.MakeNewUserGoals;
using VirtualWellnessProgram.Models;
using VirtualWellnessProgram.Models.ViewModels;
using VirtualWellnessProgram.Models.View_Models;

namespace VirtualWellnessProgram.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.ApplicationUser).Include(c => c.Group).Include(c => c.HealthInfo);
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
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create(ApplicationUser user)
        {
            //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Code");
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "GroupName");
            //ViewBag.HealthId = new SelectList(db.HealthInfoes, "Id", "UniqueCode");
            CustomerCreateViewModel viewModel = new CustomerCreateViewModel();
            viewModel.user = user;
            viewModel.groups = db.Groups.ToList();

            return View(viewModel);

        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateViewModel viewModel1)
        {
            if (ModelState.IsValid)
            {
                string code = viewModel1.user.Code;
                string healthidstring = db.HealthInfoes.Where(m => m.UniqueCode == code).Select(m =>m.Id).ToString();
                int healthid = Int32.Parse(healthidstring);
                MakeNewUserGoals.Goals goals = new Goals();
                double calories = goals.Calorie(healthid);

                Customer customer = new Customer();
                customer.HealthId = healthid;
                customer.FirstName = viewModel1.customer.FirstName;
                customer.LastName = viewModel1.customer.LastName;
                customer.GroupId = viewModel1.customer.GroupId;
                customer.CalorieGoal = calories;
                customer.ApplicationUserId = viewModel1.user.Id;
                customer.Captain = false;
                customer.VigorousDuration = 75;
                customer.ModerateDuration = 150;
                customer.CaloriesPending = false;
                customer.CalorieYearlyPoints = 0;
                customer.CalorieMonthlyPoints = 0;
                customer.CaloriesToAdd = 0;
                customer.CurrentCalorieCount = 0;
                customer.ModerateNumberToAdd = 0;
                customer.CurrentModerateDuration = 0;
                customer.ExercisePending = false;
                customer.VigorousNumberToAdd = 0;
                customer.Day = DateTime.Today;

                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            CustomerCreateViewModel viewModel = new CustomerCreateViewModel();
            var username = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == username).First();

            viewModel.user = currentUser;
            viewModel.groups = db.Groups.ToList();

            return View(viewModel);
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
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Code", customer.ApplicationUserId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "GroupName", customer.GroupId);
            ViewBag.HealthId = new SelectList(db.HealthInfoes, "Id", "UniqueCode", customer.HealthId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Day,CurrentVigorousDuration,VigorousNumberToAdd,ExercisePending,CurrentModerateDuration,ModerateNumberToAdd,CalorieGoal,CurrentCalorieCount,CaloriesToAdd,CalorieMonthlyPoints,CalorieYearlyPoints,CaloriesPending,ModerateDuration,VigorousDuration,Captain,ApplicationUserId,HealthId,GroupId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Code", customer.ApplicationUserId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "GroupName", customer.GroupId);
            ViewBag.HealthId = new SelectList(db.HealthInfoes, "Id", "UniqueCode", customer.HealthId);
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

        public ActionResult ChangeGroupId()
        {
            CustomerEditGroupIdViewModel viewModel = new CustomerEditGroupIdViewModel();
            viewModel.Customers = db.Customers.ToList();
            viewModel.Groups = db.Groups.ToList();
            return View(viewModel);
        }

        public ActionResult EditGroupId(int? id)
        {
            Customer customer = db.Customers.Find(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult EditGroupId(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChangeGroupId");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Code", customer.ApplicationUserId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "GroupName", customer.GroupId);
            ViewBag.HealthId = new SelectList(db.HealthInfoes, "Id", "UniqueCode", customer.HealthId);
            return View(customer);
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
