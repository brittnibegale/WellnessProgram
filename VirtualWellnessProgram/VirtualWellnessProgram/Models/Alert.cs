using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Input your group change request here")]
        public string Alerts { get; set; }

        public bool Read { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}