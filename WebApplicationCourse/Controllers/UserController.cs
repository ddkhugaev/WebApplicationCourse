using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers
{
    public class UserController : Controller
    {
        readonly IUsersRepository usersRepository;
        public UserController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            ModelState.Remove("ConfirmPassword");
            if (!usersRepository.IsPasswordCorrect(user.Login, user.Password))
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
            }
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
            if (usersRepository.IsLoginExist(user.Login))
            {
                ModelState.AddModelError("", "Такой логин уже используется");
            }
            if (ModelState.IsValid)
            {
                usersRepository.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
