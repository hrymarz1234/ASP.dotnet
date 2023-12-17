using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;
namespace Laboratorium_2

{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public enum Operators
        {
            Add, Mul, Sub, Div
        }
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Calculator(string op, double x, double y)
        {

            double result = 0;
            if (op == "sub")
            {
                result = x - y;

            }
            else if (op == "add")
            {
                result = x + y;

            }
            else if (op == "div")
            {
                result = x / y;

            }
            else if (op == "mul")
            {
                result = x * y;

            }

            ViewBag.Result = result;
            return View();
        }
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
    }
}
