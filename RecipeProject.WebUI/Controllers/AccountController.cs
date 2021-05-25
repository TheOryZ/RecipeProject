using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeProject.WebUI.ApiServices.Interfaces;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLogin appUserLogin)
        {
            if(ModelState.IsValid)
            {
                if(await _authService.Login(appUserLogin))
                {
                    return RedirectToAction("Index","Home", new {@area="Admin"});
                }
                ModelState.AddModelError("","Username or Password is wrong");
            }
            return View(appUserLogin);
        }
    }
}