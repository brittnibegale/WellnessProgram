using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WellnessProject.Models
{
    public class Exercise
    {
        public int Id { get; set;}

        [Display(Name = "Moderate Cardio Goal")]
        public double ModerateDuration { get; set; }

        [Display(Name = "Vigorous Cardio Goal")]
        public double VigorousDuration { get; set; }

    }
}