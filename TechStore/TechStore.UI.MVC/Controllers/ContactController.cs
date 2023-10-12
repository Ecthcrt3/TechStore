using Microsoft.AspNetCore.Mvc;

namespace TechStore.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
