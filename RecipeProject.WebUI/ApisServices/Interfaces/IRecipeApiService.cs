using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.ApiServices.Interfaces
{
    public interface IRecipeApiService
    {
        Task<List<RecipeList>> GetAllAsync();
        Task<RecipeList> GetByIdAsync(string id);
        Task AddAsync(RecipeAdd recipeAdd);
        Task UpdateAsync(string id ,RecipeUpdate recipeUpdate);
        Task DeleteAsync(string id);

    }
}