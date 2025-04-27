using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            return View(productsRepository);
        }
        public IActionResult DeleteProduct(int id)
        {
            productsRepository.TryRemoveById(id);
            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EditProduct(int id)
        {
            var product = productsRepository.TryGetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productsRepository.EditById(product.Id, product);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
