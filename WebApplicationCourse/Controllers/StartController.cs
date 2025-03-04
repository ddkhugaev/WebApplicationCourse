using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCourse.Controllers
{
    public class StartController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string Hello()
        {
            int hour = DateTime.Now.Hour;
            if (hour < 6)
            {
                return "Доброй ночи";
            }
            if (hour < 12)
            {
                return "Доброе утро";
            }
            if (hour < 18)
            {
                return "Добрый день";
            }
            return "Добрый вечер";
        }
    }
}
