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

        //private List<PetViewModel> ListCategoryPetDog(int quantity, int categoryid)
        //{
        //    var ListCategoryPetDog = from c in _dbContext.CategoryPets
        //                             join p in _dbContext.Pets
        //                             on c.Id equals p.CategoryPetId
        //                             join i in _dbContext.PetImages
        //                             on p.Id equals i.PetId
        //                             where c.CategoryId == categoryid
        //                             select new PetViewModel()
        //                             {
        //                                 Id = p.Id,
        //                                 Name = p.Name,
        //                                 Description = p.Description,
        //                                 Age = p.Age,
        //                                 Price = p.Price,
        //                                 Status = p.Status,
        //                                 CategoryId = c.Id,
        //                                 Uri = i.Uri
                                         
        //                             };
        //    ListCategoryPetDog.OrderByDescending(p => p.Id).Take(quantity);
        //    return ListCategoryPetDog.ToList();
        //}

        // Method get all 10 Pets
        private IEnumerable<Pet> GetPets(int quantity)
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

        public ActionResult Category()
        {
            
            var viewCategory = new PetViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                CategoryPets = _dbContext.CategoryPets.ToList()
            };

            return PartialView(viewCategory);
        }

        public ActionResult Products(int id)
        {
            var viewProducts = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(i => i.CategoryPetId == id).ToList(),
                //lợi làm tới đây thôi, mệt vl, hình làm chưa ra

                CategoryPets = _dbContext.CategoryPets.Where(c => c.Id == id).ToList(),

                // Get PetImages
                PetImages = _dbContext.PetImages.ToList()              
            };

            return View(viewProducts);
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

        private IEnumerable<Pet> GetCategorypet(int quantity, int id)
        {
            // Order by lastest Id
            return _dbContext.Pets.OrderByDescending(p => p.Id).Take(quantity).Where(s => s.CategoryPetId != id).ToList();
        }

        public ActionResult ListOtherProducts(int id)
        {
            var list = GetCategorypet(3,id);
            var ListSimilarProducts = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(i => i.CategoryPetId != id).ToList(),
                //lợi làm tới đây thôi, mệt vl, hình làm chưa ra

                CategoryPets = _dbContext.CategoryPets.Where(c => c.Id != id).ToList(),

                // Get PetImages
                PetImages = _dbContext.PetImages.ToList()
            };

            return PartialView(ListSimilarProducts);
        }
    }
}