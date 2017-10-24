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
        private IEnumerable<Pet> GetPets(int quantity)
        {
            // Order by lastest Id
            return _dbContext.Pets.OrderByDescending(p => p.Id).Take(quantity).ToList();
        }


        // GET: Pet
        public ActionResult Index()
        {
            var list = GetPets(16);

            var viewModel = new PetViewModel
            {
                PetImages = _dbContext.PetImages.ToList(),
                Pets = list,
            };

            return View(viewModel);
        }

        public ActionResult Category()
        {
            var view = new PetViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                CategoryPets = _dbContext.CategoryPets.ToList()
            };

            return PartialView(view);
        }

        public ActionResult Products(int id)
        {
            var viewProducts = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(i => i.CategoryPetId == id).ToList(),

                CategoryPets = _dbContext.CategoryPets.Where(c => c.Id == id).ToList(),

                // Get PetImages
                PetImages = _dbContext.PetImages.ToList()              
            };

            return View(viewProducts);
        }

        public ActionResult PetDetails(int id)
        {
            var viewModel = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(p => p.Id == id).ToList(),
                PetImages = _dbContext.PetImages.ToList(),
            };

            return View(viewModel);
        }

        public ActionResult ListCategory()
        {
            var viewListCategory = new PetViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                CategoryPets = _dbContext.CategoryPets.ToList()
            };

            return PartialView(viewListCategory);
        }

        private IEnumerable<Pet> GetRandomPets(int quantity)
        {
            return _dbContext.Pets.OrderBy(p => Guid.NewGuid()).Take(quantity).ToList();
        }

        public ActionResult ListOtherProducts(int id)
        {
            var list = GetRandomPets(2);
            var viewModel = new PetViewModel
            {
                Pets = list,
                CategoryPets = _dbContext.CategoryPets.Where(c => c.Id != id).ToList(),
                PetImages = _dbContext.PetImages.ToList()
            };

            return PartialView(viewModel);
        }

        public ActionResult RelatedPets(int petId)
        {
            var viewModel = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(p => p.Id != petId).OrderBy(p => Guid.NewGuid()).Take(6).ToList(),
                PetImages = _dbContext.PetImages.ToList()
            };

            return PartialView(viewModel);
        }

        public ActionResult YourCart()
        {
            

            return View();
        }
    }
}