using Microsoft.AspNetCore.Mvc;

namespace RecipeProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}