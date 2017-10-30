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
        public double CurrentModerateDuration { get; set; }
        public double? ModerateNumberToAdd { get; set; }

        [Display(Name = "Vigorous Cardio Goal")]
        public double VigorousDuration { get; set; }
        public double CurrentVigorousDuration { get; set; }
        public double? VigorousNumberToAdd { get; set; }
        public bool Pending { get; set; }

    }
}