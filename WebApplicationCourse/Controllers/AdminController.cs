using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class AdminController : Controller
    {
        readonly IProductsRepository productsRepository;
        readonly IOrdersRepository ordersRepository;
        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Orders");
        }
        public IActionResult Orders()
        {
            return View(ordersRepository);
        }
        public IActionResult EditOrder(Guid id)
        {
            var order = ordersRepository.TryGetById(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult EditOrder(Guid id, OrderStatus status)
        {
            var order = ordersRepository.TryGetById(id);
            ordersRepository.UpdateOrderStatus(id, status);
            return RedirectToAction("Orders");
        }
        //public IActionResult OrderNewStatus(Guid id, string status)
        //{
        //    var order = ordersRepository.TryGetById(id);
        //    order.Status = status;
        //    return RedirectToAction("EditOrder", new { id = id });
        //}
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
                return RedirectToAction("Products");
            }
            return View();
        }
    }
}
