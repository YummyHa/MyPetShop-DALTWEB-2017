using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPetShop.Models;

namespace MyPetShop.ViewModels
{
    public class PetViewModel
    {
        public IEnumerable<Pet> Pets { get; set; }
        
        public IEnumerable<PetImage> PetImages { get; set; }
    }
}