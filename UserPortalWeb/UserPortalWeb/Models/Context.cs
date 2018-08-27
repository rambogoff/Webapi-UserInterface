using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserPortalWeb.Models
{
    public class Context : DbContext
    {
        public Context() : base("UserPortal") // database name 
        { 


        }

        public DbSet<User> Users { get; set; }
    }
}