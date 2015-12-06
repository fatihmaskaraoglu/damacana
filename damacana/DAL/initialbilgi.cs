using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Damacana.Models;
namespace damacana.DAL
{
    public class initialbilgi : System.Data.Entity.DropCreateDatabaseIfModelChanges<bilgi>
    {
        protected override void Seed(bilgi context)
        {
            var products = new List<Product>
            {
                new Product{id=1,name="erikliiiii",price=(decimal)6.20},
            };
            products.ForEach(s => context.Products1.Add(s));
            context.SaveChanges();

            var carts = new List<Cart>
            {
                new Cart{id=1, totalAmount= (decimal) 35.2, userId=1,items = new List<KeyValuePair<Product, int>>()},
            };
            carts.ForEach(s => context.carts.Add(s));
            context.SaveChanges();

            var purchases = new List<Purchase>
            {
                new Purchase{id=1, userId=1, totalPrice =(decimal)45.2}
            };
           purchases.ForEach(s => context.Purchases.Add(s));
            context.SaveChanges();


        }
    }
}