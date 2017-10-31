using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WellnessProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Input the code you were given after your screening here")]
        public string Code { get; set; }

        public DateTime Day { get; set; }
        public double? CurrentVigorousDuration { get; set; }
        public double? VigorousNumberToAdd { get; set; }
        public bool ExercisePending { get; set; }
        public double? CurrentModerateDuration { get; set; }
        public double? ModerateNumberToAdd { get; set; }

        [Display(Name = "Calorie Goal")]
        public double? CalorieGoal { get; set; }

        [Display(Name = "Today's Calorie Intake")]
        public double? CurrentCalorieCount { get; set; }

        public double? CaloriesToAdd { get; set; }

        [Display(Name = "Personal Monthly Points")]
        public double? CalorieMonthlyPoints { get; set; }

        [Display(Name = "Personal Total Yearly Points")]
        public double? CalorieYearlyPoints { get; set; }
        public bool CaloriesPending { get; set; }

        [Display(Name = "Moderate Cardio Goal")]
        public double ModerateDuration { get; set; }

        [Display(Name = "Vigorous Cardio Goal")]
        public double VigorousDuration { get; set; }

        [Display(Name = "Captain Role")]
        public bool Captain { get; set; }

        [Display(Name = "Achievements")]
        public List<string>Achievements { get; set; }

        [ForeignKey("HealthId")]
        public HealthInfo HealthInfo { get; set; }
        public int? HealthId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<Group>Groups { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Group>Groups { get; set; }
        public DbSet<HealthInfo>HealthInfos { get; set; }
        public DbSet<Exercise>Exercises { get; set; }
        public DbSet<Achievement>Achievements { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}