using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
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
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult RemoveRole(string name)
        {
            rolesRepository.Remove(name);
            return RedirectToAction("Index");
        }
    }
}
