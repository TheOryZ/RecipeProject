using Microsoft.AspNetCore.Mvc;

namespace RecipeProject.WebUI.ViewComponents
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}