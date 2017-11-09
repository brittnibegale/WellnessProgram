using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class AlertEditViewModel
    {
        public Alert Alert { get; set; }

        [Required]
        [Display(Name="Group Name")]
        public string Response { get; set; }
    }
}