using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.WebUI.ApiServices.Interfaces;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService; 
        public CategoryController(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryApiService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryListModel model)
        {
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryListModel model)
        {
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }
    }
}