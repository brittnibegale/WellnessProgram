using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VirtualWellnessProgram.Migrations;

namespace VirtualWellnessProgram.Models
{
    public class CalorieAlert
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Calorie Goal")]
        public double CalorieGoal { get; set; }

        [Display(Name = "Calories Consumed")]
        public double CaloriesConsumed { get; set; }

        [Display(Name = "Group Members First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Group Members Last Name")]
        public string CustomerLastName { get; set; }

        public bool Read { get; set; }

        public int Group { get; set; }

        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }
        public int CustomerId { get; set; }

    }
}