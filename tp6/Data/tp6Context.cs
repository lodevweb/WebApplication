using DojoClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace tp6.Data
{
    public class tp6Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public tp6Context() : base("name=tp6Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme);
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtMartials).WithMany();
        }


        public System.Data.Entity.DbSet<DojoClassLibrary.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<DojoClassLibrary.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<DojoClassLibrary.ArtMartial> ArtMartials { get; set; }
    }
}
