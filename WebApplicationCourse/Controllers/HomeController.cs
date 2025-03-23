using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //public IActionResult Index()
    //{
    //    return View();
    //}

    public string Index(int id=-1)
    {
        string ans = "";
        List<Product> products = [new Product("Картье", 200, "Хороший"), new Product("Портье", 4500, "Тоже хороший")];
        foreach (var product in products)
        {
            if (product.Id == id)
            {
                return product.ToString();
            }
            ans += product.ToString() + "\n";
        }
        return ans;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
