using System.Threading.Tasks;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.ApiServices.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(AppUserLogin appUserLogin);
        void LogOut();
    }
}