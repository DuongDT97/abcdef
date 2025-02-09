using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test2.Models;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
<<<<<<< HEAD
            return View();
            //toi bi ngu
=======
 return View();
>>>>>>> c01c61294cefb67489f6b748b92fc5e0149df224
        }

        public IActionResult Privacy()
        {
            //test
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
