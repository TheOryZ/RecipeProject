using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<List<CategoryListModel>> GetAllAsync();
    }
}