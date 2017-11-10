using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using VirtualWellnessProgram.Audit;
using VirtualWellnessProgram.Models;
using VirtualWellnessProgram.Models.ViewModels;

namespace VirtualWellnessProgram.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                group.UpdatedDate = DateTime.Today.ToString("MM/dd/yyyy");
                group.GroupName.ToLower();
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Audit]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupName,GroupCaloriePoints,GroupExercisePoints,TotalPoints")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [Audit]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Audit]
        public ActionResult Points()
        {
            var groups = db.Groups.ToList();
            var humans = db.Customers.ToList();
            foreach (var group in groups)
            {
                foreach (var people in humans)
                {
                    double totalResult = 0;

                    if (people.GroupId == group.Id)
                    {
                        if (group.UpdatedDate != DateTime.Today.ToString("MM/dd/yyyy"))
                        {
                            double totalPoints = people.CalorieYearlyPoints + people.ExerciseYearlyPoints + people.ExerciseMonthlyPoints + people.CalorieMonthlyPoints;
                            totalResult += totalPoints;
                        }
                    }
                    if (totalResult > group.TotalPoints)
                    {
                        group.TotalPoints = totalResult;
                        db.Entry(group).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            var result = db.Groups.OrderByDescending(g => g.TotalPoints).ToList();
            GroupPointsViewModel groupPoints = new GroupPointsViewModel();
            groupPoints.Group = result;

            return View(groupPoints);
        }

        public ActionResult MyGroupsPoints()
        {
            var currentUserName = User.Identity.Name;
            var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).ToString();
            var currentCustomerIdString = db.Customers.Where(m => m.ApplicationUserId == currentUserId).Select(m => m.Id).ToString();
            var currentCustomerId = Int32.Parse(currentCustomerIdString);
            var currentCustomerGroupIdString = db.Customers.Where(m => m.Id == currentCustomerId).Select(m => m.GroupId).ToString();
            var currentCustomerGroupId = Int32.Parse(currentCustomerGroupIdString);
            var currentGroupExercise = db.Groups.Where(m => m.Id == currentCustomerGroupId).Select(m => m.GroupExercisePoints).ToString();
            var currentGroupCalorie = db.Groups.Where(m => m.Id == currentCustomerGroupId).Select(m => m.GroupCaloriePoints).ToString();
            var currentGroupExcerisePoints = Double.Parse(currentGroupExercise);
            var currentGroupCaloriePoints = Double.Parse(currentGroupCalorie);

            GroupMyGroupsPointsViewModel viewModel = new GroupMyGroupsPointsViewModel();
            viewModel.GroupCalorie = currentGroupCaloriePoints;
            viewModel.GroupExercise = currentGroupExcerisePoints;

            return View(viewModel);
        }

        public ActionResult EditGroupName()
        {
            var currentUsername = User.Identity.Name;
            var currentUser = db.Users.Where(m => m.UserName == currentUsername).Select(m => m.Id).ToString();
            var currentCustomerGroupIdString = db.Customers.Where(m => m.ApplicationUserId == currentUser).Select(m => m.GroupId).ToString();
            var currentCustomerGroupId = Int32.Parse(currentCustomerGroupIdString);
            var group = db.Groups.Where(m => m.Id == currentCustomerGroupId).First();

            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGroupName(Group group)
        {
            db.Entry(group).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
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
