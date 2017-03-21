using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LexiconMDB.Models;

namespace LexiconMDB.DAL
{
    public class LexiconMDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LexiconMDBContext() : base("name=LexiconMDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DatabaseContextInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
