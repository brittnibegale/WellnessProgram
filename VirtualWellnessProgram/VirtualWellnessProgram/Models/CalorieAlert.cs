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

        public double CalorieGoal { get; set; }

        public double CaloriesConsumed { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public bool Read { get; set; }


        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }
        public int CustomerId { get; set; }

    }
}