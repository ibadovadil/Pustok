using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SitePustok.Contexts;

namespace SitePustok.Contollers
{
    public class HomeController : Controller
    {
       PustokDBContext _db { get; }

        public HomeController(PustokDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            
            var sliders = await _db.Sliders.ToListAsync();
            return View(sliders);
        }
    }
}
