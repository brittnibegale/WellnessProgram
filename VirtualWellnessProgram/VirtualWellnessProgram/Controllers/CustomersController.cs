using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualWellnessProgram.Audit;
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
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateViewModel viewModel1)
        {
            if (viewModel1.customer.GroupId != null)
            {

                string userName = User.Identity.Name;
                var userCode = db.Users.Where(m => m.UserName == userName).Select(m => m.Code).First();
                var userId = db.Users.Where(m => m.UserName == userName).Select(m => m.Id).First();
                string userCoderesult = userCode;
                var healthidstring = db.HealthInfoes.Where(m => m.UniqueCode == userCoderesult).Select(m =>m.Id).First();
                int healthid = healthidstring;

                MakeNewUserGoals.Goals goals = new Goals();
                double calories = goals.Calorie(healthid);

                Customer customer = new Customer();
                customer.HealthId = healthid;
                customer.FirstName = viewModel1.customer.FirstName;
                customer.LastName = viewModel1.customer.LastName;
                customer.GroupId = viewModel1.customer.GroupId;
                customer.CalorieGoal = calories;
                customer.ApplicationUserId = userId;
                customer.Captain = false;
                customer.VigorousDuration = 75;
                customer.ModerateDuration = 150;
                customer.CaloriesPending = false;
                customer.CalorieYearlyPoints = 0;
                customer.CalorieMonthlyPoints = 0;
                customer.ExerciseYearlyPoints = 0;
                customer.ExerciseMonthlyPoints = 0;
                customer.CurrentCalorieCount = 0;
                customer.ModerateNumberToAdd = 0;
                customer.VigorousNumberToAdd = 0;
                customer.CurrentCalorieCount = 0;
                customer.ExercisePending = false;
                customer.Day = DateTime.Today.ToString("MM/dd/yyyy");

                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index","Home");
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
        [Audit]
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
        [Audit]
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

        [Audit]
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

        public ActionResult ChangeCaptainStatus()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult EditCaptainStatus(int? id)
        {
            Customer customer = db.Customers.Find(id);

            return View(customer);
           
        }

        [Audit]
        [HttpPost]
        public ActionResult EditCaptainStatus(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChangeCaptainStatus");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Code", customer.ApplicationUserId);
            ViewBag.GroupId = new SelectList(db.Groups, "Id", "GroupName", customer.GroupId);
            ViewBag.HealthId = new SelectList(db.HealthInfoes, "Id", "UniqueCode", customer.HealthId);
            return View(customer);
        }

        public ActionResult Points()
        {
            var currentUsername = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).First();
            var currentCustomer = db.Customers.Where(m => m.ApplicationUserId == currentUser).First();

            CustomerPointsViewModel viewModel = new CustomerPointsViewModel();
            viewModel.CalorieMonthlyPoints = currentCustomer.CalorieMonthlyPoints;
            viewModel.CalorieYearlyPoints = currentCustomer.CalorieYearlyPoints;
            viewModel.ExerciseMonthlyPoints = currentCustomer.ExerciseMonthlyPoints;
            viewModel.ExerciseYearlyPoints = currentCustomer.ExerciseYearlyPoints;

            return View(viewModel);
        }

        public ActionResult GetFoodItem()
        {
            FoodAPIViewModel search = new FoodAPIViewModel();
            return View();
        }

        [HttpPost]
        public ActionResult GetFoodItem(FoodAPIViewModel search)
        {
            var searchWord = search.SearchWordInput;
            var foodList = USDAAPI.SearchFood.UsdaCall(searchWord);
            search.food = foodList;

            return View(search);
        }

        public ActionResult GetFoodInfo(string id)
        {
            var info = USDAAPI.SearchFood.GetFood(id);
            var calories = info.Report.Foods[0].Nutrients[0].Value;
            double calorieResult = Math.Round(Double.Parse(calories));
            var userName = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == userName).Select(m => m.Id).First();
            var currentCustomer = db.Customers.Where(m => m.ApplicationUserId == currentUser).First();
           
            UpdateCustomer.UpdateCalories view = new UpdateCustomer.UpdateCalories();
            var customer = view.EditCalories(calorieResult, currentCustomer);

            return View(customer);
        }

        public ActionResult AddExercise()
        {
            CustomerAddExerciseViewModel viewModel = new CustomerAddExerciseViewModel();
            viewModel.MuscleTraining = false;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExercise(CustomerAddExerciseViewModel viewModel)
        {
            var currentUserName = User.Identity.Name;
            var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).First();
            var currentCustomerId = db.Customers.Where(m => m.ApplicationUserId == currentUserId).Select(m => m.Id).First();
            var currentCustomer = db.Customers.Where(m => m.Id == currentCustomerId).First();
            var moderate = viewModel.ModerateTraining;
            var vigorous = viewModel.VigorousTraining;

            if (moderate > 0)
            {
                currentCustomer.ModerateNumberToAdd += moderate;
                currentCustomer.ExercisePending = true;
            }

            if (vigorous > 0)
            {
                currentCustomer.VigorousNumberToAdd += vigorous;
                currentCustomer.ExercisePending = true;
            }

            db.Entry(currentCustomer).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ExerciseTotal");
        }

        public ActionResult ExerciseTotal()
        {
            var currentUserName = User.Identity.Name;
            var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).First();
            var currentCustomer = db.Customers.Where(m => m.ApplicationUserId == currentUserId).First();

            return View(currentCustomer);
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
