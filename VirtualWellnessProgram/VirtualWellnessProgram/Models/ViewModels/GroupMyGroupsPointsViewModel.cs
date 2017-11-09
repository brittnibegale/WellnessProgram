using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class GroupMyGroupsPointsViewModel
    {
        [Display(Name = "Current Group Exercise Points: ")]
        public double GroupExercise { get; set; }
        [Display(Name ="Current Group Calorie Points: ")]
        public double GroupCalorie { get; set; }
    }
}