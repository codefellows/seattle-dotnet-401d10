using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class CartItems
    {
        public int ID { get; set; }

        public int CartID { get; set; }

        public int Quantity { get; set; }

        // create what's called "shadow property" and this field in the db will look like a FK.
        public Inventory Service { get; set; }


    }
}
