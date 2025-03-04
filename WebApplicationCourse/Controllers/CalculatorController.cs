using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Controllers
{
    public class CalculatorController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string Index(float a, float b, string oper = "+")
        {
            switch (oper)
            {
                case "+": return $"{a} + {b} = {a + b}";
                case "-": return $"{a} - {b} = {a - b}";
                case "*": return $"{a} * {b} = {a * b}";
                default: return "Возможные операции: '+', '-', '*'";
            }
        }
    }
}
