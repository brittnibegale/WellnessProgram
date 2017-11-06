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

        public void FindCustomer(string email)
        {
            var currentUserId= db.Users.Where(m => m.Email == email).Select(m => m.Id).ToString();
            var currentCustomer = db.Customers.Where(m => m.ApplicationUserId == currentUserId).First();

            CheckCurrentDay(currentCustomer);
        }

        private void CheckCurrentDay(Customer customer)
        {
            if (customer.Day != DateTime.Today)
            {
                if (customer.CaloriesPending == true)
                {
                    CreateCalorieAmount(customer);
                }
                if (customer.Day.DayOfWeek.Equals(DayOfWeek.Friday))
                {
                    if (customer.ExercisePending == true)
                    {
                        CreateExerciseAmount(customer);
                    }
                }
                EditCustomerDay(customer);
            }
        }

        private void CreateCalorieAmount(Customer customer)
        {
            List<double> calories = customer.CaloriesToAdd;

            double totalCalories = 0;

            for (int i = 0; i < calories.Count; i++)
            {
                totalCalories += calories[i];
            }

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
            if (customer.ModerateNumberToAdd.Count > 0)
            {
                for (int i = 0; i < customer.ModerateNumberToAdd.Count; i++)
                {
                    totalModerateAmount += customer.ModerateNumberToAdd[i];
                }
            }
            if (customer.VigorousNumberToAdd.Count > 0)
            {
                for (int i = 0; i < customer.VigorousNumberToAdd.Count; i++)
                {
                    totalVigorusAmount += customer.VigorousNumberToAdd[i];
                }
            }
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
            customer.Day = DateTime.Today;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}