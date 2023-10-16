using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TechStore.DATA.EF.Models;
using TechStore.UI.MVC.Models;

namespace TechStore.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreFrontContext _context;

        public HomeController(ILogger<HomeController> logger, StoreFrontContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return _context.Categories != null ?
                        View(await _context.Categories.ToListAsync()) :
                        Problem("Entity set 'StoreFrontContext.Categories'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}