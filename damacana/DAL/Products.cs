using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Damacana.Models;

namespace damacana.DAL
{
    public class bilgi : DbContext
    {
            public bilgi() : base("bilgi")
        {
        }
        
        public DbSet<Product> Products1 { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}