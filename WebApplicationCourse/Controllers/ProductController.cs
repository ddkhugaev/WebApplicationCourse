using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        public string Index(int id)
        {
            Product product = productRepository.TryGetById(id);
            if (product == null)
            {
                return $"Продукта с id={id} не существует!";
            }
            return $"{product}\n{product.Description}";
        }
    }
}
