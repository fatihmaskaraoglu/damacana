using System;
using System.Collections.Generic;

namespace Damacana.Models
{
    public class Purchase
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime createdOn { get; set; }
        public List<KeyValuePair<Product, int>> items { get; set; }
        public decimal totalPrice;
    }
}