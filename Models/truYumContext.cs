using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TruYum_Asp.Models
{
    public class truYumContext:DbContext
    {
        public truYumContext() : base("TruYumContext") { }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<MenuItems> MenuItem { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}