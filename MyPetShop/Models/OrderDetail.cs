using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyPetShop.Models
{
    public class OrderDetail
    {
        public Order Order { get; set; }
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        public Pet Pet { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PetId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}