using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitePustok.Areas.Admin.ViewModels;
using SitePustok.Contexts;
using SitePustok.Models;
using SitePustok.ViewModels.ProductVM;
using SitePustok.Helpers;

namespace SitePustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        PustokDBContext _db { get; }
        IWebHostEnvironment _env { get; }

        public ProductController(PustokDBContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {

            return View(_db.Products.Select(p => new AdminProductListItemVM
            {
                Id = p.Id,
                SellPrice = p.SellPrice,
                CostPrice = p.CostPrice,
                Discount = p.Discount,
                Category = p.Category,
                CategoryId = p.CategoryId,
                IsDeleted = p.IsDeleted,
                ImageUrl = p.ImageUrl,


            }));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.IsCorrectType())
                {
                    ModelState.AddModelError("ImageFile", "Wrong file type");
                }
                if (!vm.ImageFile.IsValidSize())
                {
                    ModelState.AddModelError("ImageFile", "Files length must be less than kb");
                }

            }

            if (vm.Images != null)
            {
                foreach (var img in vm.Images)
                {
                    if (!img.IsCorrectType())
                    {
                        ModelState.AddModelError("", "Wrong file type (" + img.FileName + ")");
                    }
                    if (!img.IsValidSize(200))
                    {
                        ModelState.AddModelError("", "Files length must be less than kb (" + img.FileName + ")");
                    }
                }

            }




            if (vm.CostPrice > vm.SellPrice)
            {
                ModelState.AddModelError("CostPrice", "Sell price must be bigger than cost price");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _db.Categories;
                ViewBag.Products = _db.Products;
                return View(vm);
            }
            if (!await _db.Categories.AnyAsync(c => c.Id == vm.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Category doesnt exist");
                ViewBag.Products = _db.Products;
                ViewBag.Categories = _db.Categories;
                return View(vm);
            }

            Product product = new Product
            {
                Title = vm.Title,
                Description = vm.Description,
                SellPrice = vm.SellPrice,
                CostPrice = vm.CostPrice,
                Availability = vm.Availability,
                Brand = vm.Brand,
                CategoryId = (int)vm.CategoryId,
                Discount = vm.Discount,
                ImageUrl = await vm.ImageFile.SaveAsync(PathConstants.Product),
                Qunatity = vm.Qunatity,
                RewardPoint = vm.RewardPoint,
                ProductImage = vm.Images.Select(i => new ProductImage
                {
                    ImageUrl = i.SaveAsync(PathConstants.Product).Result
                }).ToList(),
            };
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null) return BadRequest();

            var data = await _db.Products.FindAsync(Id);
            if (data == null) return NotFound();
            _db.Products.Remove(data);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
            //if (Id == null || Id <= 0) return BadRequest();
            //var data = await _db.Products.FindAsync(Id);
            //if (data == null) return NotFound();
            //return View(new SliderUpdateVM
            //{
            //    Title = data.Title,
            //    IsLeft = data.IsLeft switch
            //    {
            //        true => 1,
            //        false => 0,
            //    },
            //    IsRightText = data.IsRightText switch
            //    {
            //        true => 1,
            //        false => 0,
            //    },
            //});
        }
    }
}
