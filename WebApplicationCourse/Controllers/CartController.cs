using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class CartController : Controller
    {
        readonly ProductsRepository productsRepository;
        public CartController()
        {
            productsRepository = new ProductsRepository();
        }
        public IActionResult Index()
        {
            var cart = CartsRepository.TryGetById(Constants.UserId);
            return View(cart);
        }
        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            CartsRepository.Add(product, Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
