using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPetShop.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }

        public Pet Pet { get; set; }

        public string Image { get; set; }

    }
}