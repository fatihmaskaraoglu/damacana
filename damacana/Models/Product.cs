using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Damacana.Models
{

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }


    }
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
