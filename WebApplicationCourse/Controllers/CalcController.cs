using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Controllers
{
    public class CalcController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string Index(float a, float b, string c = "+")
        {
            switch (c)
            {
                case null:
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                case "/": return $"{a} / {b} = {a / b}";
                default: return "Введите одну из операций '+', '-', '*', '/'";
            }
        }
    }
}
