using Microsoft.AspNet.Identity.EntityFramework;
using Books.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Web.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb() : base("DefaultConnection")
        {

        }
    }
}