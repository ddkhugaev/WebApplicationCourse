using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

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
        [HttpPost]
        public IActionResult Index(User user)
        {
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                return Content(user.ToString());
            }
            return View(user);
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (user.Login == user.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return Content(user.ToString());
            }
            return View(user);
        }
    }
}
