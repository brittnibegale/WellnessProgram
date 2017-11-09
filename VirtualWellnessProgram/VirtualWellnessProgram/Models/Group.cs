using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "Total Calorie Points")]
        public double GroupCaloriePoints { get; set; }

        [Display(Name = "Total Exercise Points")]
        public double GroupExercisePoints { get; set; }

        [Display(Name = "Total Points")]
        public double TotalPoints { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string UpdatedDate { get; set; }

    }
}