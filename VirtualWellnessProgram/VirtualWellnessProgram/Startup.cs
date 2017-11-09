using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrackerEnabledDbContext.Common.Configuration;
using VirtualWellnessProgram.Models;

[assembly: OwinStartupAttribute(typeof(VirtualWellnessProgram.Startup))]
namespace VirtualWellnessProgram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "Brittni";
                user.Email = "brittnibegale@gmail.com";
                user.Code = "1234";

                string userPWD = "Brittni#1";
               
                    var chkUser = UserManager.Create(user, userPWD);
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");
                    }
              


               
            }
            if (!roleManager.RoleExists("Registered User"))
            {
                var role = new IdentityRole();
                role.Name = "Registered User";
                roleManager.Create(role);
            }
        }
    }
}
