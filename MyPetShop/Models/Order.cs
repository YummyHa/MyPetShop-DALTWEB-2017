using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyPetShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // if status = 1 then pending
        // if status = 0 then completed
        [Required]
        public int Status { get; set; }

        [ForeignKey("IdentityUser")]
        [Required]
        public int UserId { get; set; }

        public IdentityUser IdentityUser { get; set; }

    }
}