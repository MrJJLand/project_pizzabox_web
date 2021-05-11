using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositores;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly UnitOfWork _uow;
        public CustomerController(UnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [HttpGet]
        public IActionResult CustomerCheck(CustomerViewModel _customer)
        {
            if (ModelState.IsValid)
            {
                var customer = _uow.Customers.Select(c => c.FirstName == _customer.FirstName).First();
                customer = _uow.Customers.Select(c => c.LastName == _customer.LastName).First();
            }
            return View("customer", _customer);
        }
    }
}