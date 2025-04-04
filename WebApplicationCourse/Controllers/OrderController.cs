using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class OrderController : Controller
    {
        readonly ICartsRepository cartsRepository;
        readonly IOrdersRepository ordersRepository;
        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(string name, string address, string phone)
        {
            var existingCart = cartsRepository.TryGetById(Constants.UserId);
            var order = new Order(name, phone, address, existingCart);
            ordersRepository.Add(order);
            cartsRepository.Remove(existingCart);
            return View(order);
        }
    }
}
