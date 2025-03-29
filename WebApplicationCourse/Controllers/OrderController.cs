using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Buy()
        {
            var existingCart = cartsRepository.TryGetById(Constants.UserId);
            ordersRepository.Add(existingCart);
            existingCart.ItemsCart.Clear();
            return View();
        }
    }
}
