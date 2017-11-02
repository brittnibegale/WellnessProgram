using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualWellnessProgram.Models;

namespace VirtualWellnessProgram.MakeNewUserGoals
{
    public class Goals
    {
        private ApplicationDbContext db;

        public Goals()
        {
            db = new ApplicationDbContext();
        }

        public double Calorie(Customer customer)
        {
            string health = customer.HealthId.ToString();
            int healthid = Int32.Parse(health);

            int age = GetAge(healthid);
            double bodyFat = GetBodyFat(healthid);
            string gender = GetGender(healthid);

            double calories = 0;
            if (gender == "female")
            {
                calories = DetermineFemaleCalorieGoal(age, bodyFat);
            }
            else if (gender == "male")
            {
                calories = DetermineMaleCalorieGoal(age, bodyFat);
            }

            return calories;
        }

        public int GetAge(int healthid)
        {
            string age = db.HealthInfoes.Where(m => m.Id == healthid).Select(m => m.Age).ToString();
            int ageResult = Int32.Parse(age);

            return ageResult;
        }

        public double GetBodyFat(int healthid)
        {
            string bodyfat = db.HealthInfoes.Where(m => m.Id == healthid).Select(m => m.BodyFatAmt).ToString();
            double bodyFatResult = Double.Parse(bodyfat);

            return bodyFatResult;
        }

        public string GetGender(int healthid)
        {
            string gender = db.HealthInfoes.Where(m => m.Id == healthid).Select(m => m.Gender).ToString();

            return gender;
        }

        public double DetermineFemaleCalorieGoal(int age, double bodyfat)
        {
            double calorieGoal = 0;

            if (age == 18)
            {
                if (bodyfat >= 1 && bodyfat <= 16)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 17 && bodyfat <= 30)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 31 && bodyfat <= 50)
                {
                    calorieGoal = 1600;
                }
            }
            else if (age == 19)
            {
                if (bodyfat >= 1 && bodyfat <= 18)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 19 && bodyfat <= 31)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 32 && bodyfat <= 50)
                {
                    calorieGoal = 1600;
                }
            }
            else if (age >= 20 && age <= 39)
            {
                if (bodyfat >= 1 && bodyfat <= 20)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 21 && bodyfat <= 32)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 33 && bodyfat <= 50)
                {
                    calorieGoal = 1500;
                }
            }
            else if (age >= 40 && age <= 59)
            {
                if (bodyfat >= 1 && bodyfat <= 22)
                {
                    calorieGoal = 2100;
                }
                else if (bodyfat >= 23 && bodyfat <= 33)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 34 && bodyfat <= 50)
                {
                    calorieGoal = 1500;
                }
            }
            else if (age == 60)
            {
                if (bodyfat >= 1 && bodyfat <= 23)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 24 && bodyfat <= 35)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 35 && bodyfat <= 50)
                {
                    calorieGoal = 1500;
                }
            }

            return calorieGoal;
        }
        public double DetermineMaleCalorieGoal(int age, double bodyfat)
        {
            double calorieGoal = 0;

            if (age == 18)
            {
                if (bodyfat >= 1 && bodyfat <= 9)
                {
                    calorieGoal = 2800;
                }
                else if (bodyfat >= 10 && bodyfat <= 19)
                {
                    calorieGoal = 2100;
                }
                else if (bodyfat >= 20 && bodyfat <= 50)
                {
                    calorieGoal = 1700;
                }
            }
            else if (age == 19)
            {
                if (bodyfat >= 1 && bodyfat <= 8)
                {
                    calorieGoal = 2800;
                }
                else if (bodyfat >= 9 && bodyfat <= 19)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 20 && bodyfat <= 50)
                {
                    calorieGoal = 1700;
                }
            }
            else if (age >= 20 && age <= 39)
            {
                if (bodyfat >= 1 && bodyfat <= 7)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 8 && bodyfat <= 19)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 20 && bodyfat <= 50)
                {
                    calorieGoal = 1600;
                }
            }
            else if (age >= 40 && age <= 59)
            {
                if (bodyfat >= 1 && bodyfat <= 10)
                {
                    calorieGoal = 2100;
                }
                else if (bodyfat >= 11 && bodyfat <= 21)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 22 && bodyfat <= 50)
                {
                    calorieGoal = 1500;
                }
            }
            else if (age == 60)
            {
                if (bodyfat >= 1 && bodyfat <= 12)
                {
                    calorieGoal = 2500;
                }
                else if (bodyfat >= 13 && bodyfat <= 24)
                {
                    calorieGoal = 2000;
                }
                else if (bodyfat >= 25 && bodyfat <= 50)
                {
                    calorieGoal = 1500;
                }
            }

            return calorieGoal;
        }
    }
}