using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectoryOrganizations.Models;
using Microsoft.EntityFrameworkCore.Storage;
namespace DirectoryOrganizations.Controllers
{
    public class BranchesController : Controller
    {

        ApplicationContext db;
        public BranchesController (ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var results = await db.Branches.Include(x => x.Address).Include(x => x.Organization).ToListAsync();
            return View(results);
        }
        public IActionResult Create()
        {
            ViewBag.Addresses = new List<Address>(db.Address.ToList());
            ViewBag.Organizations = new List<Organization>(db.Organizations.ToList());
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Branch branch)
        {
            db.Branches.Add(branch);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
				Branch? branch = await db.Branches.FirstOrDefaultAsync(p => p.Id == id);
				if (branch != null)
				{
					db.Branches.Remove(branch);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if( id != null)
            {
				ViewBag.Addresses = new List<Address>(db.Address.ToList());
				ViewBag.Organizations = new List<Organization>(db.Organizations.ToList());
				Branch? branch = await db.Branches.FirstOrDefaultAsync(p => p.Id == id);
                if (branch!= null) return View(branch);
			}
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Branch branch)
        {
            db.Branches.Update(branch);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
		[HttpPost]
		public IActionResult Back()
		{
			return Redirect("~/Home/Index");
		}
	}
}
