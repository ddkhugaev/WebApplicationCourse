using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class CartController : Controller
    {
        readonly IProductsRepository productsRepository;
        readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult IncreaseCount(Guid itemCartId)
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            cart.ItemsCart.FirstOrDefault(itemCart => itemCart.Id == itemCartId).IncreaseCount();
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseCount(Guid itemCartId)
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            var itemCart = cart.ItemsCart.FirstOrDefault(itemCart => itemCart.Id == itemCartId);
            itemCart.DecreaseCount();
            if (itemCart.Count < 1)
            {
                cart.RemovePositionFromCart(itemCart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Ordering(Guid cartId)
        {
            return View(cartsRepository.TryGetById(Constants.UserId));
        }
        public IActionResult Success(Guid cartId)
        {
            cartsRepository.TryGetById(Constants.UserId).ItemsCart.Clear();
            return RedirectToAction("Index");
        }
    }
}
