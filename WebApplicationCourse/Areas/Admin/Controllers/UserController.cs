using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        readonly IUsersRepository usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            return View(usersRepository);
        }
        public IActionResult UserDetails(Guid id)
        {
            var user = usersRepository.TryGetById(id);
            return View(user);
        }
        public IActionResult ChangePassword(Guid id)
        {
            var user = usersRepository.TryGetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            var oldUser = usersRepository.TryGetById(user.Id);
            oldUser.Password = user.Password;
            oldUser.ConfirmPassword = user.ConfirmPassword;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(Guid id)
        {
            usersRepository.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult EditUser(Guid id)
        {
            var user = usersRepository.TryGetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            var oldUser = usersRepository.TryGetById(user.Id);
            oldUser.Login = user.Login;
            oldUser.Name = user.Name;
            oldUser.Surname = user.Surname;
            oldUser.Phone = user.Phone;
            return RedirectToAction("Index");
        }
    }
}
