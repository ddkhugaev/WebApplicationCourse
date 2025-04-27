using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
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
            return RedirectToAction("Index");
        }
        //public IActionResult OrderNewStatus(Guid id, string status)
        //{
        //    var order = ordersRepository.TryGetById(id);
        //    order.Status = status;
        //    return RedirectToAction("EditOrder", new { id = id });
        //}
    }
}
