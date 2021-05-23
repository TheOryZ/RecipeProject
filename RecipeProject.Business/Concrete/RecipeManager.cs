using RecipeProject.Business.Interfaces;
using RecipeProject.DataAccess.Interfaces;
using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Concrete
{
    public class RecipeManager : IRecipeService
    {
        private readonly IRecipeDal _recipeDal;
        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }
        public async Task AddAsync(Recipe recipe)
        {
            await _recipeDal.AddAsync(recipe);
        }

        public async Task<Recipe> FindByIdAsync(string id)
        {
            return await _recipeDal.FindByIdAsync(id);
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _recipeDal.GetAllAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _recipeDal.RemoveAsync(id);
        }

        public async Task UpdateAsync(string id, Recipe recipe)
        {
            await _recipeDal.UpdateAsync(id, recipe);
        }
    }
}
