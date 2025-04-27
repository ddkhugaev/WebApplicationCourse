using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        readonly IProductsRepository productsRepository;
        readonly IOrdersRepository ordersRepository;
        readonly IRolesRepository rolesRepository;
        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
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
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже сущетсвует");
            }
            else
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            return View(role);
        }
        public IActionResult RemoveRole(string name)
        {
            rolesRepository.Remove(name);
            return RedirectToAction("Roles");
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
