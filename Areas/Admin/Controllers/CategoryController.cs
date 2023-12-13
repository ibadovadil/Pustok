﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitePustok.Contexts;
using SitePustok.Models;
using SitePustok.ViewModels.CategoryVM;

namespace SitePustok.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		PustokDBContext _db { get; }

		public CategoryController(PustokDBContext db)
		{
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _db.Categories.Select(c => new CategoryListItemVM
			{
				Id = c.Id,
				Name = c.Name,
				ParentCategoryId = c.ParentCategoryId,
				IsDeleted = c.IsDeleted,
			}).Take(5).ToListAsync());


		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]

		public async Task<IActionResult> Create(CategoryCreateVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			if (await _db.Categories.AnyAsync(x => x.Name == vm.Name))
			{
				ModelState.AddModelError("Name", "This Name Already Exist");
				return View(vm);
			}
			Category category = new Category
			{
				Name = vm.Name,
				ParentCategoryId = vm.ParentCategoryId,
				IsDeleted = vm.IsDeleted switch
				{
					true => true,
					false => false
				},

			};
			await _db.Categories.AddAsync(category);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


		public IActionResult ShowMoreButton(int page = 1, int pageSize = 5)
		{
			var records = _db.Categories.ToList()
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

				return View(records);
		}
		public IActionResult GetMoreRecords(int page = 1, int pageSize = 5)
		{
			var records = _db.Categories.Select(c => new CategoryListItemVM
			{
				Id = c.Id,
				Name = c.Name,
				ParentCategoryId = c.ParentCategoryId,
				IsDeleted = c.IsDeleted,
			})
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

            return PartialView("_RecordPartial", records);

		}
	}
}
