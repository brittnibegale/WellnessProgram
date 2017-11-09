using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class ExerciseAlert
    {
        [Key]
        public int Id { get; set; }

        public double VigorousGoal { get; set; }
        public double ModerateGoal { get; set; }
        public double currentVigorous { get; set; }
        public double currentModerate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public bool Read { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


    }
}