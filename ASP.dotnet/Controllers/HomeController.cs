using ASP.dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace ASP.dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public enum Operator
        {
            Unknown, Add, Mul, Sub, Div
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Calculator(double a, double b, Operator op)
        {
            ViewBag.Op = op;
            ViewBag.A = a;
            ViewBag.B = b;

            if (op == Operator.Add)
                ViewBag.wynik = a + b;

            else if (op == Operator.Sub)
                ViewBag.wynik = a - b;

            else if (op == Operator.Mul)
                ViewBag.wynik = a * b;

            else if (op == Operator.Div)
                ViewBag.wynik = a / b;
            
            return View();
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
}