using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.View_Models
{
    public class CustomerCreateViewModel
    {
        public  ApplicationUser user { get; set; }

        public Customer customer { get; set; }
        [Required]
        [Display(Name = "Choose Group")]
        public List<Group> groups { get; set; }

    }
}