using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCourse.Models;

namespace WebApplicationCourse.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    readonly ProductRepository productRepository;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        productRepository = new ProductRepository();
    }

    //public IActionResult Index()
    //{
    //    return View();
    //}

    
    public string Index()
    {
        List<Product> products = productRepository.GetAll();
        string ans = "";
        foreach (var product in products)
        {
            ans += product.ToString() + "\n\n";
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
