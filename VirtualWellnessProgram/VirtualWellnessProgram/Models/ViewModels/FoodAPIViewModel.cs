using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualWellnessProgram.Models.ViewModels
{
    public class FoodAPIViewModel
    {
        [Display(Name = "Food to Search")]
        public string SearchWordInput { get; set; }
        public SearchFoodAPI food { get; set; }
    }
}