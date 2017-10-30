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

        [ForeignKey("HealthId")]
        public HealthInfo HealthInfo { get; set; }
        public int HealthId { get; set; }

        [ForeignKey("CalorieId")]
        public Calories Calories { get; set; }
        public int CalorieId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("AchievementId")]
        public Achievement Achievement { get; set; }
        public int AchievementId { get; set; }


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