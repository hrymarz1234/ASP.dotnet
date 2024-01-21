using Laboratorium_3.Models;
using Laboratorium_3.Services;
using Laboratorium_3.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

[Authorize(Roles = "Admin")]
public class ContactController : Controller
{
    
    private readonly IContactService _contactService;
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View(_contactService.FindAll());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult CreateApi(Contact c)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(c);
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public IActionResult PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 5)
    {
        return View(_bookService.FindPage(page, size));
    }

    public ActionResult Edit(int id)
    {
        return View();
    }

    [HttpGet]
    public ActionResult Create()
    {
        Contact model = new Contact();
        model.Organization = _contactService
            .FindAllOrganizations()
            .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
            .ToList();
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Contact model)
    {
        if (ModelState.IsValid)
        {
            _contactService.Add(model);
            return RedirectToAction("Index");
        }
        else
        {
            return View(model);
        }

    }
    
    
}