using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WellnessProject.Models
{
    public class Calories
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Calorie Goal")]
        public double Goal { get; set; }

        [Display(Name = "Today's Calorie Intake")]
        public double CurrentCalorieCount { get; set; }

        public double? CaloriesToAdd { get; set; }

        [Display(Name = "Personal Monthly Points")]
        public double MonthlyPoints { get; set; }

        [Display(Name = "Personal Total Yearly Points")]
        public double YearlyPoints { get; set; }
        public bool Pending { get; set; }
    }
}