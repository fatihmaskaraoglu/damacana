using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Damacana.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Product> PurchaseList { get; set; }

        public virtual User User { get; set; }

    }
    public class PurchaseDBContext : DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<Damacana.Models.User> Users { get; set; }
    }
}