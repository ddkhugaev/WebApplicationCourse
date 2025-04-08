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
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                var existingCart = cartsRepository.TryGetById(Constants.UserId);
                //var order = new Order(name, phone, address, existingCart);
                order.CartOrder = existingCart;
                ordersRepository.Add(order);
                cartsRepository.Remove(existingCart);

                return Content(order.ToString());
            }
            return View(order);
        }
    }
}
