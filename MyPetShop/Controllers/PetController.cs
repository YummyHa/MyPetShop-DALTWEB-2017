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

        // Method Add Pet to Cart
        [HttpPost]
        [Authorize]
        public JsonResult AddToCart(int id, int quantity)
        {
            List<CartItem> listCartItem;
            if (Session["ShoppingCart"] == null)
            {
                listCartItem = new List<CartItem>
                {
                    new CartItem
                    {
                        Quantity = quantity,
                        Pet = _dbContext.Pets.Find(id),
                        Image = _dbContext.PetImages.Single(m => m.PetId == id).Uri.ToString(),
                    }
                };

                Session["ShoppingCart"] = listCartItem;
            }
            else
            {
                var flag = false;
                listCartItem = (List<CartItem>) Session["ShoppingCart"];
                foreach (var cartItem in listCartItem)
                {
                    if (cartItem.Pet.Id != id) continue;
                    cartItem.Quantity += quantity;
                    flag = true;
                    break;
                }
                if (!flag)
                {
                    listCartItem.Add(new CartItem
                    {
                        Quantity = quantity,
                        Pet = _dbContext.Pets.Find(id),
                        Image = _dbContext.PetImages.Single(m => m.PetId == id).Uri.ToString(),
                    });
                }
                Session["ShoppingCart"] = listCartItem;
            }

            // Count number of Items in Shopping Cart
            var list = (List<CartItem>) Session["ShoppingCart"];
            var cartCount = list.Sum(item => item.Quantity);
            return Json(new {ItemAmount = cartCount});
        }

        public ActionResult GetShoppingCart()
        {
            var cartCount = 0;
            if (Session["ShoppingCart"] == null) return PartialView("ShoppingCartPartial", cartCount);

            var list = (List<CartItem>) Session["ShoppingCart"];
            cartCount += list.Sum(item => item.Quantity);

            return PartialView("ShoppingCartPartial", cartCount);
        }

        public ActionResult ListCartItem()
        {
            return View();
        }

    }
}