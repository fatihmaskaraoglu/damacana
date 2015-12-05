using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damacana.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int userId { get; set; }
        public List<KeyValuePair<Product, int>> items { get; set; }
        public decimal totalAmount;
    }
}