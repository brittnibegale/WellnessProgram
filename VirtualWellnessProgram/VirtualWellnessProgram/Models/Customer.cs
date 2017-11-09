using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace VirtualWellnessProgram.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string Day { get; set; }

        public double VigorousNumberToAdd { get; set; }
        public bool ExercisePending { get; set; }
        public double ModerateNumberToAdd { get; set; }

        [Display(Name = "Calorie Goal")]
        public double CalorieGoal { get; set; }

        [Display(Name = "Today's Calorie Intake")]
        public double CurrentCalorieCount { get; set; }

        [Display(Name = "Personal Monthly Points")]
        public double CalorieMonthlyPoints { get; set; }

        [Display(Name = "Personal Total Yearly Points")]
        public double CalorieYearlyPoints { get; set; }
        public bool CaloriesPending { get; set; }

        [Display(Name = "Moderate Cardio Goal")]
        public double ModerateDuration { get; set; }

        [Display(Name = "Vigorous Cardio Goal")]
        public double VigorousDuration { get; set; }

        public double ExerciseMonthlyPoints { get; set; }

        public double ExerciseYearlyPoints { get; set; }

        [Display(Name = "Captain Role")]
        public bool Captain { get; set; }

        [Display(Name = "Achievements")]
        public List<string> Achievements { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        [ForeignKey("HealthId")]
        public HealthInfo HealthInfo { get; set; }
        public int? HealthId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        [Display(Name = "Group")]
        public int GroupId { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
