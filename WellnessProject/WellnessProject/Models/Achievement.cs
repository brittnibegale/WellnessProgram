using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WellnessProject.Models
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Your Achievements")]
        public List<string>Achievments { get; set; }

    }
}