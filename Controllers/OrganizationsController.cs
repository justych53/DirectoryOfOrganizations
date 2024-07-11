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
	public class OrganizationsController : Controller
	{
		ApplicationContext db;
		public OrganizationsController(ApplicationContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
		{
			var result = await db.Organizations.Include(x=>x.Category).ToListAsync();
			return View(result);
		}
		public IActionResult Create()
		{
			ViewBag.Categories = new List<Category>(db.Categories.ToList());
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Organization organization)
		{
			db.Organizations.Add(organization);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id != null)
			{
				Organization? organization = await db.Organizations.FirstOrDefaultAsync(p => p.Id == id);
				if (organization != null)
				{
					db.Organizations.Remove(organization);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			return NotFound();
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null)
			{
				ViewBag.Categories = new List<Category>(db.Categories.ToList());
				Organization? organization = await db.Organizations.FirstOrDefaultAsync(p => p.Id == id);
				if (organization != null) return View(organization);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Organization organization)
		{
			db.Organizations.Update(organization);
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
