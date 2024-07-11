using DirectoryOrganizations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOrganizations.Controllers
{
    public class HomeController : Controller
    {
		ApplicationContext db;
		public HomeController(ApplicationContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
        {
            var result = await db.Organizations.Include(x => x.Category).Include(x => x.Branches).ThenInclude(x => x.Address).ToListAsync();
            return View(result);
        }
        [HttpPost]
        public IActionResult Categories()
        {
            return Redirect("~/Categories/Index");
        }
        [HttpPost]
        public IActionResult Addresses()
        {
            return Redirect("~/Addresses/Index");
        }
        [HttpPost]
        public IActionResult Organizations()
        {
            return Redirect("~/Organizations/Index");
        }
        [HttpPost]
        public IActionResult Branches()
        {
            return Redirect("~/Branches/Index");
        }
    }
}
