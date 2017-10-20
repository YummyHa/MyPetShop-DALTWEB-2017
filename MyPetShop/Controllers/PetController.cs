using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPetShop.Models;
using MyPetShop.ViewModels;

namespace MyPetShop.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PetController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // Method get all 10 Pets
        private List<Pet> GetPets(int quantity)
        {
            // Order by lastest Id
            return _dbContext.Pets.OrderByDescending(p => p.Id).Take(quantity).ToList();
        }


        // GET: Pet
        public ActionResult Index()
        {
            var list = GetPets(10);

            var viewModel = new PetViewModel
            {
                PetImages = _dbContext.PetImages.ToList(),
                Pets = _dbContext.Pets.ToList()
            };

            return View(viewModel);
        }
    }
}