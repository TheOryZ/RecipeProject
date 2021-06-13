using Microsoft.AspNetCore.Mvc;

namespace RecipeProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}