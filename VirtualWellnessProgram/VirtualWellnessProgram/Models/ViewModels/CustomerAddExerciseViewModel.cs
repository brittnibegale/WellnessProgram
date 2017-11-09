using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class CustomerAddExerciseViewModel
    {
        [Display(Name = "Strength Training")]
        public bool MuscleTraining { get; set; }

        [Display(Name = "Minutes of Vigorous Training")]
        public double VigorousTraining { get; set; }

        [Display(Name = "Minutes of Moderate Training")]
        public double ModerateTraining { get; set; }
    }
}