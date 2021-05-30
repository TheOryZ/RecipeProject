using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.WebUI.ApiServices.Interfaces;

namespace RecipeProject.WebUI.Controllers 
{
    public class HomeController : Controller
    {
        private readonly IRecipeApiService _recipeApiService;
        public HomeController(IRecipeApiService recipeApiService)
        {
            _recipeApiService = recipeApiService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _recipeApiService.GetAllAsync());
        }

        public async Task<IActionResult> RecipeDetail(string id)
        {
            return View(await _recipeApiService.GetByIdAsync(id));
        }
    }
}