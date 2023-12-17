using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Laboratorium_3.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        private readonly IDateTimeProvider _dateTimeProvider;

        public BookController(IDateTimeProvider timeProvider, IBookService bookService)
        {
            _dateTimeProvider = timeProvider;
            _bookService = bookService;
            
        }

        public IActionResult Index()
        {
            return View(_bookService.FindAll());
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_bookService.FindById(id));
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (ModelState.IsValid)
            {

                _bookService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_bookService.FindById(id));
        }


        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookService.DeleteById(model.Id);
            return RedirectToAction("Index");
        }
    }
}
