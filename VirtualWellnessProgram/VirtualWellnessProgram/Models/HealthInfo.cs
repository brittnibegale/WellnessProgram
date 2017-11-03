using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class HealthInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Persons Unique Code")]
        public string UniqueCode { get; set; }

        [Required]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Are they a smoker?")]
        public bool Smoker { get; set; }

        [Required]
        [Display(Name = "Body Fat %")]
        public string BodyFatAmt { get; set; }

        [Required]
        [Display(Name = "High Density Lipoprotein Amount")]
        public string Hdl { get; set; }

        [Required]
        [Display(Name = "Low Density Lipoprotein Amount")]
        public string Ldl { get; set; }

        [Required]
        [Display(Name = "Total Cholesterol Level")]
        public string CholesterolTotal { get; set; }

        [Required]
        [Display(Name = "Total Triglyeride level")]
        public string Triglycerides { get; set; }
    }
}