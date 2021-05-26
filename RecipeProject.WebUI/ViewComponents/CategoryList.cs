using Microsoft.AspNetCore.Mvc;
using RecipeProject.WebUI.ApiServices.Interfaces;

namespace RecipeProject.WebUI.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryList(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryApiService.GetAllAsync().Result);
        }
    }
}