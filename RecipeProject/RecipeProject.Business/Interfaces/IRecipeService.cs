using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Interfaces
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe> FindByIdAsync(string id);
        Task AddAsync(Recipe recipe);
        Task UpdateAsync(string id, Recipe recipe);
        Task RemoveAsync(string id);
    }
}
