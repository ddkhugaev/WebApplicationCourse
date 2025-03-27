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
    }
}
