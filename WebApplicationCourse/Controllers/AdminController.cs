using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class AdminController : Controller
    {
        readonly IProductsRepository productsRepository;
        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Orders");
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View(productsRepository);
        }
        public IActionResult DeleteProduct(int id)
        {
            productsRepository.TryRemoveById(id);
            return RedirectToAction("Products");
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string name, int cost, string description)
        {
            var product = new Product(name, cost, description);
            productsRepository.AddProduct(product);
            return RedirectToAction("Products");
        }
    }
}
