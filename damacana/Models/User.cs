using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damacana.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}