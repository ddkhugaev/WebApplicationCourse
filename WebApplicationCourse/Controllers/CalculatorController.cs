using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Controllers
{
    public class CalculatorController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string Index(float a, float b)
        {
            return $"{a} + {b} = {a + b}";
        }
    }
}
