namespace EmployeesRegister.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeesRegister.DataAccessLayer.EmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeesRegister.DataAccessLayer.EmployeesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Employees.AddOrUpdate(
              p => p.FirstName,
              new Models.Employee { FirstName = "Per", LastName = "Nordenbrink" },
              new Models.Employee { FirstName = "Nils", LastName = "Nordenbrink" },
              new Models.Employee { FirstName = "Carl", LastName = "Nordenbrink" }
            );
        }

    }
}
