namespace STAS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<STAS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(STAS.Models.ApplicationDbContext context)
        {
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);

            //var roleNames = new[] { "Admin", "Editor" };
            //foreach (var roleName in roleNames)
            //{
            //    if (!context.Roles.Any(r => r.Name == roleName))
            //    {
            //        var role = new IdentityRole { Name = roleName };
            //        var results = roleManager.Create(role);

            //        if (!results.Succeeded)
            //        {
            //            throw new Exception(string.Join("\n", results.Errors));
            //        }
            //    }
            //}

            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);
            //var emails = new[] { "admin@gymbokning.se", "per@lexicon.se" };
            //foreach (var email in emails)
            //{
            //    if (!context.Users.Any(u => u.UserName == email))
            //    {
            //        var user = new ApplicationUser
            //        {
            //            UserName = email,
            //            Email = email
            //        };
            //        var result = userManager.Create(user, "foobar");
            //        if (!result.Succeeded)
            //        {
            //            throw new Exception(string.Join("\n", result.Errors));
            //        }
            //    }
            //}

            //var adminUser = userManager.FindByName("admin@gymbokning.se");
            //userManager.AddToRole(adminUser.Id, "Admin");


            DateTime time = DateTime.Now;

            context.Users.AddOrUpdate(
               v => v.Id,
               new ApplicationUser { FirstName = "Tore", LastName="Thjelvarsson", UserName = "tore@gymbokning.se", Email ="tore@gymbokning.se", TimeOfRegistration = time},
               new ApplicationUser { FirstName = "Cozette", LastName = "El-Boustany", UserName = "cozette@gymbokning.se", Email="cozette@gymbokning.se" , TimeOfRegistration = time }
               );
        }
    }
}
