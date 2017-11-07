using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class CustomerPointsViewModel
    {
        [Display(Name = "Yearly Calorie Points")]
        public double CalorieYearlyPoints { get; set; }

        [Display(Name = "Monthly Calorie Points")]
        public double CalorieMonthlyPoints { get; set; }

        [Display(Name = "Yearly Exercise Points")]
        public double ExerciseYearlyPoints { get; set; }
        
        [Display(Name = "Monthly Exercise Points")]
        public double ExerciseMonthlyPoints { get; set; }
    }
}