using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using VirtualWellnessProgram.Models;
using System.Data.Entity;

namespace VirtualWellnessProgram.CheckLoginUser
{
    public class CheckDay
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void FindCustomer(string UserName)
        {
            var currentUserId= db.Users.Where(m => m.UserName == UserName).Select(m => m.Id).ToString();
            var currentCustomer = db.Customers.Where(m => m.ApplicationUserId == currentUserId).First();

            CheckCurrentDay(currentCustomer);
        }

        private void CheckCurrentDay(Customer customer)
        {
            if (customer.Day != DateTime.Today.ToString("MM/dd/yyyy"))
            {
                if (customer.CaloriesPending == true)
                {
                    CreateCalorieAmount(customer);
                }
                if (customer.Day.Equals(DayOfWeek.Friday.ToString()))
                {
                    if (customer.ExercisePending == true)
                    {
                        CreateExerciseAmount(customer);
                    }//get right language for this
                }
                if (DateTime.Today.Day == 1)
                {
                    EditCustomerMonthlyPointsandDay(customer);
                }
                else
                {
                    EditCustomerDay(customer);
                }
            }
        }

        private void CreateCalorieAmount(Customer customer)
        {
            double calories = customer.CurrentCalorieCount;
            double totalCalories = 0;

            totalCalories += calories;

            CreateCalorieAlert(totalCalories, customer);
        }

        private void CreateCalorieAlert(double calories, Customer customer)
        {
            CalorieAlert calorieAlert = new CalorieAlert();
            calorieAlert.CaloriesConsumed = calories;
            calorieAlert.CustomerFirstName = customer.FirstName;
            calorieAlert.CustomerLastName = customer.LastName;
            calorieAlert.CustomerId = customer.Id;
            calorieAlert.CalorieGoal = customer.CalorieGoal;
            calorieAlert.Read = false;

            db.CalorieAlerts.Add(calorieAlert);
            db.SaveChanges();
        }

        private void CreateExerciseAmount(Customer customer)
        {
            double totalModerateAmount = 0;
            double totalVigorusAmount = 0;
           
            totalModerateAmount += customer.ModerateNumberToAdd;
            totalVigorusAmount += customer.VigorousNumberToAdd;
            
            CreateExerciseAlert(totalVigorusAmount, totalModerateAmount, customer);
        }

        private void CreateExerciseAlert(double vigorous, double moderate, Customer customer)
        {
            ExerciseAlert exerciseAlert = new ExerciseAlert();
            exerciseAlert.CustomerFirstName = customer.FirstName;
            exerciseAlert.CustomerLastName = customer.LastName;
            exerciseAlert.CustomerId = customer.Id;
            exerciseAlert.ModerateGoal = customer.ModerateDuration;
            exerciseAlert.VigorousGoal = customer.VigorousDuration;
            exerciseAlert.currentModerate = moderate;
            exerciseAlert.currentVigorous = vigorous;
            exerciseAlert.Read = false;

            db.ExerciseAlerts.Add(exerciseAlert);
            db.SaveChanges();
        }

        private void EditCustomerDay(Customer customer)
        {
            customer.Day = DateTime.Today.ToString("MM/dd/yyyy");

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        private void EditCustomerMonthlyPointsandDay(Customer customer)
        {
            customer.ExerciseYearlyPoints += customer.ExerciseMonthlyPoints;
            customer.ExerciseMonthlyPoints = 0;
            customer.CalorieYearlyPoints += customer.CalorieMonthlyPoints;
            customer.CalorieMonthlyPoints = 0;
            customer.Day = DateTime.Today.ToString("MM/dd/yyyy");

            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}