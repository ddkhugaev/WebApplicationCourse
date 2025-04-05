using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
