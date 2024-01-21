using Data;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrgnanizationApiController : Controller
    {
        
        
        private readonly AppDbContext _context;

        public OrgnanizationApiController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetFiltered(string filter)
            {
                return Ok(_context.Organizations
                    .Where(o => o.Title.StartsWith(filter))
                    .Select(o => new { o.Title, o.Id })
                    .ToList());
            }
        
    }
}
