using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyPetShop.Models;
using MyPetShop.ViewModels;

namespace MyPetShop.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CheckOutController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: ShoppingCart
        public ActionResult PlaceOrder()
        {
            var userId = User.Identity.GetUserId();
            var user = _dbContext.Users.Single(u => u.Id == userId);

            CheckOutViewModel viewModel = new CheckOutViewModel
            {
                Name = user.Name,
                Address = user.Address,
                Phone = user.PhoneNumber,
            };

            return View(viewModel);
        }

        
        [HttpPost]
        public ActionResult PlaceOrder(CheckOutViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                user.Address = viewModel.Address;
                user.Name = viewModel.Name;
                user.PhoneNumber = viewModel.Phone;
                _dbContext.SaveChanges();
            }
            else
            {
                return Json(new { url = Url.Action("Login", "Account") });
            }

            // Add Order
            var order = new Order
            {
                Date = DateTime.Now,
                Status = 1,
                UserId = userId,
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            var lastOrderId = _dbContext.Orders.OrderByDescending(o => o.Id).Single().Id;

            // Add OrderDetail
            var list = (List<CartItem>) Session["ShoppingCart"];
            foreach (var cartItem in list)
            {
               var detail = new OrderDetail
               {
                   OrderId = lastOrderId,
                   PetId = cartItem.Pet.Id,
                   Quantity = cartItem.Quantity,
               };
               _dbContext.OrderDetails.Add(detail);
                _dbContext.SaveChanges();
            }

            Session["ShoppingCart"] = null;

            
            return RedirectToAction("Index", "Home");
        }

    }
}