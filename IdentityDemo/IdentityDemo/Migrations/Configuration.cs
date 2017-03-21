namespace IdentityDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdentityDemo.Models.ApplicationDbContext";
        }

        protected override void Seed(IdentityDemo.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { "Admin", "Editor" };
            foreach (var roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName) )
                {
                    var role = new IdentityRole { Name = roleName };
                    var results = roleManager.Create(role);

                    if(!results.Succeeded)
                    {
                        throw new Exception(string.Join("\n", results.Errors));
                    }
                }
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var emails = new[] { "jocke@lexicon.se", "editor@lexicon.se", "admin@lexicon.se", "root@lexicon.se" };
            foreach (var email in emails)
            {
                if (!context.Users.Any(u => u.UserName == email))
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email
                    };
                    var result = userManager.Create(user, "foobar");
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }
            }

            var adminUser = userManager.FindByName("admin@lexicon.se");
            userManager.AddToRole(adminUser.Id, "Admin");

            var editorUser = userManager.FindByName("editor@lexicon.se");
            userManager.AddToRole(editorUser.Id, "Editor");

            var rootUser = userManager.FindByName("root@lexicon.se");
            userManager.AddToRole(rootUser.Id, "Admin");
            userManager.AddToRole(rootUser.Id, "Editor");
        }
    }
}
