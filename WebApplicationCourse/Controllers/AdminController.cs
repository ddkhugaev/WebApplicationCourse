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
        public IActionResult AddProduct(Product product)
        {
            //var product = new Product() { Name = name, Description = description, Cost = cost};
            if (ModelState.IsValid)
            {
                productsRepository.AddProduct(product);
                return RedirectToAction("Products");
            }
            return View();
        }
    }
}
