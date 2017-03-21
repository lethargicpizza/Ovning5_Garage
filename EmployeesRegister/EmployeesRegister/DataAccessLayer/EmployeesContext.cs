using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeesRegister.DataAccessLayer
{
    public class EmployeesContext : DbContext
    {
        public DbSet<Models.Employee> Employees { get; set; }

        public EmployeesContext() : base("DefaultConnection")
        {
            
        }
    }
}