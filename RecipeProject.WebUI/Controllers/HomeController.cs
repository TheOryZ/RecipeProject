using Microsoft.AspNetCore.Mvc;

namespace RecipeProject.WebUI.Controllers 
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}