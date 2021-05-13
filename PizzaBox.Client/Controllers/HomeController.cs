using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly UnitOfWork _uow;

        public HomeController(UnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        [HttpGet]
        public IActionResult Order()
        {
            var order = new OrderViewModel();
            order.Loader(_uow);
            return View("order", order);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("index");
        }
        [HttpGet]
        public IActionResult Store()
        {
            return View("store");
        }
    }
}
