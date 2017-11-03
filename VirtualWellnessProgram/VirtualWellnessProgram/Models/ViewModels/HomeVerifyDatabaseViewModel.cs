using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class HomeVerifyDatabaseViewModel
    {
        public DataTable Database { get; set; }

        [Required]
        [Display(Name = "Uncheck this box if data is invalid data")]
        public bool Verified { get; set; }
    }
}