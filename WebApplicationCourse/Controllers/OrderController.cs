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
        public IActionResult Buy(Order order)
        {
            var existingCart = cartsRepository.TryGetById(Constants.UserId);
            ordersRepository.Add(existingCart);
            existingCart.ItemsCart.Clear();
            return View();
        }
    }
}
