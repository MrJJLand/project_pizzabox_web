using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly UnitOfWork _uow;

        public OrderController(UnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [HttpGet]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var crust = _uow.Crusts.Select(c => c.Name == order.SelectedCrust).First();
                var size = _uow.Sizes.Select(s => s.Name == order.SelectedSize).First();
                var cheese = _uow.Cheeses.Select(c => c.Name == order.SelectedCheese).First();
                var sauce = _uow.Sauces.Select(s => s.Name == order.SelectedSauce).First();

                var toppings = new List<Topping>();
                foreach (var item in order.SelectedToppings)
                {
                    toppings.Add(_uow.Toppings.Select(t => t.Name == item).First());
                }

                var newPizza = new Pizza { Crust = crust, Size = size, Toppings = toppings, Cheese = cheese, Sauce = sauce };
                var newOrder = new Order { Pizzas = new List<Pizza> { newPizza } };

                _uow.Orders.Insert(newOrder);
                _uow.Save();

                ViewBag.Order = newOrder;

                return View("checkout");
            }
            order.Loader(_uow);
            return View("order", order);
        }
    }
}