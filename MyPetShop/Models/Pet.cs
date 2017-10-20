using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPetShop.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Age { get; set; }

        [Required]
        public double Price { get; set; }

        // Status = 0 : Available
        // Status = 1: Unavailable
        [Required]
        public int Status { get; set; }

        [Required]
        public int CategoryPetId { get; set; }
    }
}