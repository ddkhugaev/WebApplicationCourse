using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        public IActionResult Index(int id)
        {
            var product = productRepository.TryGetById(id);
            if (product == null)
            {
                return View(null);
            }
            return View(product);
        }
        public IActionResult Catalog()
        {
            var products = productRepository.GetAll();
            return View(products);
        }
        //public string Index(int id)
        //{
        //    Product product = productRepository.TryGetById(id);
        //    if (product == null)
        //    {
        //        return $"Продукта с id={id} не существует!";
        //    }
        //    return $"{product}\n{product.Description}";
        //}
    }
}
