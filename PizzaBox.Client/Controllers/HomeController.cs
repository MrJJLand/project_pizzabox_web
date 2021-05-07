using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositores;

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
        public IActionResult Index()
        {
            var order = new OrderViewModel();
            order.Loader(_uow);
            return View("order", new OrderViewModel());
        }
    }
}
