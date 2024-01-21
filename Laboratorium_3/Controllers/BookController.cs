using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Laboratorium_3.Services;
using Laboratorium_3.Services.Interfaces;


namespace Laboratorium_3.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        
        private readonly IDataTimeProvider _dateTimeProvider;

        public BookController(IBookService bookService, IDataTimeProvider dateTimeProvider)
        {
            _bookService = bookService;
            _dateTimeProvider = dateTimeProvider;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (!ModelState.IsValid)
            {
                 return View(model);
            }
            var id = _bookService.Save(model);
            TempData["ProductId"] = id;
            return RedirectToAction("Create");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (ModelState.IsValid)
            {

                
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete(Book model)
        {
           
            return RedirectToAction("Index");
        }
    }

 
}
