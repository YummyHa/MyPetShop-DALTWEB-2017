using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPetShop.Models
{
    public class PetImage
    {
        public int Id { get; set; }

        [Required]
        public string Uri { get; set; }

        [Required]
        public int PetId { get; set; }
    }
}