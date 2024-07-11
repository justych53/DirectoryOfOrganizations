using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectoryOrganizations.Models;

namespace DirectoryOrganizations.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationContext db;
        public CategoriesController (ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Categories.ToListAsync());
        }
        public IActionResult Create()
        {
        return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
				Category? category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
				if (category != null)
				{
					db.Categories.Remove(category);
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
                Category? category = await db.Categories.FirstOrDefaultAsync(p => p.Id == id);
                if (category != null) return View(category);
			}
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            db.Categories.Update(category);
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