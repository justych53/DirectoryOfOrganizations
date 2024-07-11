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
    public class AddressesController : Controller
    {
		ApplicationContext db;
		public AddressesController(ApplicationContext context)
		{
			db = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await db.Address.ToListAsync());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Address address)
		{
			db.Address.Add(address);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id != null)
			{
				Address? address = await db.Address.FirstOrDefaultAsync(p => p.Id == id);
				if (address != null)
					db.Address.Remove(address);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			return NotFound();
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null)
			{
				Address? address = await db.Address.FirstOrDefaultAsync(p => p.Id == id);
				if (address != null) return View(address);
			}
			return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Address address)
		{
			db.Address.Update(address);
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
