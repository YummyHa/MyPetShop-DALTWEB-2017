using MyPetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPetShop.ViewModels;
using MyPetShop.Models;

namespace MyPetShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pet()
        {
            var viewPet = new PetViewModel
            {
                Pets = _dbContext.Pets.ToList()
            };
            return View(viewPet);
        }

        [HttpGet]
        public ActionResult AddPet()
        {
            var viewAddPet = new PetViewModel
            {
                Pets = _dbContext.Pets.ToList(),
                CategoryPets = _dbContext.CategoryPets.ToList()
            };
            return View(viewAddPet);
        }

        [HttpPost]
        public ActionResult AddPet(FormCollection collection, Pet p)
        {
            var CB_Name = collection["txtname"];
            var CB_CategoryPetId = int.Parse(collection["categorypetid"]);
            var CB_Age = double.Parse(collection["txtage"]);
            var CB_Price = double.Parse(collection["txtprice"]);
            var CB_Description = collection["txtdes"];
            var CB_Status = int.Parse(collection["txtstatus"]);
            if (string.IsNullOrEmpty(CB_Name))
            {
                ViewData["Loi1"] = " Tên  không được để trống ";
            }
            else
            {
                p.Name = CB_Name;
                p.CategoryPetId = CB_CategoryPetId;
                p.Age = CB_Age;
                p.Price = CB_Price;
                p.Description = CB_Description;
                p.Status = CB_Status;
                _dbContext.Pets.Add(p);
                _dbContext.SaveChanges();
                return RedirectToAction("Pet", "Admin");
                
            }
            return this.AddPet();
        }

        [HttpGet]
        public ActionResult EditPet(int id)
        {
            ViewBag.CategoryPetID = new SelectList(_dbContext.CategoryPets.ToList().OrderBy(n => n.Name), "Id", "Name");
            var viewEditPet = new PetViewModel
            {               
                Pets = _dbContext.Pets.Where(m => m.Id == id).ToList(),
                CategoryPets = _dbContext.CategoryPets.ToList()
            };            
            return PartialView(viewEditPet);
        }

        [HttpPost]
        public ActionResult EditPet(int id, FormCollection collection)
        {
            var CB_Name = collection["txtname"];
            var CB_CategoryPetId = int.Parse(collection["CategoryPetID"]);
            var CB_Age = double.Parse(collection["txtage"]);
            var CB_Price = double.Parse(collection["txtprice"]);
            var CB_Description = collection["txtdes"];
            var CB_Status = int.Parse(collection["txtstatus"]);
            var Pets = _dbContext.Pets.First(m => m.Id == id);
            if (String.IsNullOrEmpty(CB_Name))
            {
                ViewData["Loi"] = "Tên không được để trống";
            }

            else
            {
                Pets.Name = CB_Name;
                Pets.CategoryPetId = CB_CategoryPetId;
                Pets.Age = CB_Age;
                Pets.Price = CB_Price;
                Pets.Description = CB_Description;
                Pets.Status = CB_Status;
                UpdateModel(Pets);
                _dbContext.SaveChanges();
                return RedirectToAction("Pet","Admin");
            }
            return this.EditPet(id);
        }

        public ActionResult DeletePet(int id)
        {
            var viewDeletePet = new PetViewModel
            {
                Pets = _dbContext.Pets.Where(m => m.Id == id).ToList()
            };
            return View(viewDeletePet);
        }

        [HttpPost]
        public ActionResult DeletePet(int id, FormCollection collection)
        {
            var Pets = _dbContext.Pets.First(m => m.Id == id);
            _dbContext.Pets.Remove(Pets);
            _dbContext.SaveChanges();
            return RedirectToAction("Pet","Admin");
        }

        public ActionResult CategoryPet()
        {
            var viewCategoryPet = new PetViewModel
            {
                CategoryPets = _dbContext.CategoryPets.ToList()
            };
            return View(viewCategoryPet);
        }

        [HttpGet]
        public ActionResult EditCategoryPet(int id)
        {
            ViewBag.CategoryID = new SelectList(_dbContext.Categories.ToList().OrderBy(n => n.Name), "Id", "Name");
            var viewEditCategoryPet = new PetViewModel
            {
                CategoryPets = _dbContext.CategoryPets.Where(m => m.Id == id).ToList(),
                Categories = _dbContext.Categories.ToList()
            };
            return PartialView(viewEditCategoryPet);
        }

        [HttpPost]
        public ActionResult EditCategoryPet(int id, FormCollection collection)
        {
            var CB_Name = collection["txtname"];
            var CB_CategoryId = int.Parse(collection["CategoryID"]);
            var CategoryPets = _dbContext.CategoryPets.First(m => m.Id == id);
            if (String.IsNullOrEmpty(CB_Name))
            {
                ViewData["Loi"] = "Tên không được để trống";
            }

            else
            {
                CategoryPets.Name = CB_Name;
                CategoryPets.CategoryId = CB_CategoryId;
                UpdateModel(CategoryPets);
                _dbContext.SaveChanges();
                return RedirectToAction("CategoryPet", "Admin");
            }
            return this.EditCategoryPet(id);
        }

        public ActionResult DeleteCategoryPet(int id)
        {
            var viewDeleteCategoryPet = new PetViewModel
            {
                CategoryPets = _dbContext.CategoryPets.Where(m => m.Id == id).ToList()
            };
            return View(viewDeleteCategoryPet);
        }

        [HttpPost]
        public ActionResult DeleteCategoryPet(int id, FormCollection collection)
        {
            var CategoryPets = _dbContext.CategoryPets.First(m => m.Id == id);
            _dbContext.CategoryPets.Remove(CategoryPets);
            _dbContext.SaveChanges();
            return RedirectToAction("CategoryPet", "Admin");
        }

        public ActionResult Category()
        {
            var viewCategory = new PetViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewCategory);
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var viewEditCategory = new PetViewModel
            {
                Categories = _dbContext.Categories.Where(m => m.Id == id).ToList(),
            };
            return PartialView(viewEditCategory);
        }

        [HttpPost]
        public ActionResult EditCategory(int id, FormCollection collection)
        {
            var CB_Name = collection["txtname"];
            var Categories = _dbContext.Categories.First(m => m.Id == id);
            if (String.IsNullOrEmpty(CB_Name))
            {
                ViewData["Loi"] = "Tên không được để trống";
            }

            else
            {
                Categories.Name = CB_Name;
                UpdateModel(Categories);
                _dbContext.SaveChanges();
                return RedirectToAction("Category", "Admin");
            }
            return this.EditCategory(id);
        }

        public ActionResult DeleteCategory(int id)
        {
            var viewDeleteCategory = new PetViewModel
            {
                Categories = _dbContext.Categories.Where(m => m.Id == id).ToList()
            };
            return View(viewDeleteCategory);
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id, FormCollection collection)
        {
            var Categories = _dbContext.Categories.First(m => m.Id == id);
            _dbContext.Categories.Remove(Categories);
            _dbContext.SaveChanges();
            return RedirectToAction("Category", "Admin");
        }

        public ActionResult PetImage()
        {
            var viewPetImage = new PetViewModel
            {
                PetImages = _dbContext.PetImages.ToList()
            };
            return View(viewPetImage);
        }

        [HttpGet]
        public ActionResult AddPetImage()
        {
            var viewAddPetImage = new PetViewModel
            {
                Pets = _dbContext.Pets.ToList(),
                PetImages = _dbContext.PetImages.ToList()
            };
            return PartialView(viewAddPetImage);
        }

        [HttpPost]
        public ActionResult AddPetImage(FormCollection collection, PetImage pi)
        {
            var CB_Uri = collection["txturi"];
            var CB_PetId = int.Parse(collection["petid"]);
            if (string.IsNullOrEmpty(CB_Uri))
            {
                ViewData["Loi1"] = " Đường dẫn không được để trống ";
            }
            else
            {
                pi.Uri = CB_Uri;
                pi.PetId = CB_PetId;
                _dbContext.PetImages.Add(pi);
                _dbContext.SaveChanges();
                return RedirectToAction("PetImage", "Admin");

            }
            return this.AddPetImage();
        }

        [HttpGet]
        public ActionResult EditPetImage(int id)
        {
            ViewBag.PetID = new SelectList(_dbContext.Pets.ToList().OrderBy(n => n.Name), "Id", "Name");
            var viewEditPetImage = new PetViewModel
            {
                PetImages = _dbContext.PetImages.Where(m => m.Id == id).ToList(),
                Pets = _dbContext.Pets.ToList()
            };
            return PartialView(viewEditPetImage);
        }

        [HttpPost]
        public ActionResult EditPetImage(int id, FormCollection collection)
        {
            var CB_Uri = collection["txtUri"];
            var CB_PetID = int.Parse(collection["PetID"]);
            var PetImages = _dbContext.PetImages.First(m => m.Id == id);
            if (String.IsNullOrEmpty(CB_Uri))
            {
                ViewData["Loi"] = "Tên không được để trống";
            }

            else
            {
                PetImages.Uri = CB_Uri;
                PetImages.PetId = CB_PetID;
                UpdateModel(PetImages);
                _dbContext.SaveChanges();
                return RedirectToAction("PetImage", "Admin");
            }
            return this.EditPetImage(id);
        }

        public ActionResult DeletePetImage(int id)
        {
            var viewDeletePetImage = new PetViewModel
            {
                PetImages = _dbContext.PetImages.Where(m => m.Id == id).ToList()
            };
            return View(viewDeletePetImage);
        }

        [HttpPost]
        public ActionResult DeletePetImage(int id, FormCollection collection)
        {
            var PetImages = _dbContext.PetImages.First(m => m.Id == id);
            _dbContext.PetImages.Remove(PetImages);
            _dbContext.SaveChanges();
            return RedirectToAction("PetImages", "Admin");
        }
    }
}