using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace damacana.Models
{
    public class cart
    {
        //IdUserId
        public int Id { get; set; }
        public int UserId { get; set; }

        Product products { get; set; }
        public virtual ICollection<Product> Product { set; get; }
        public virtual ICollection<User> users { get; set; }
    }
   
}