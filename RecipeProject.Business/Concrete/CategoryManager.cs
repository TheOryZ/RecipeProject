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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(string id)
        {
            return await _categoryDal.FindByIdAsync(id);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _categoryDal.RemoveAsync(id);
        }

        public async Task UpdateAsync(string id, Category category)
        {
            await _categoryDal.UpdateAsync(id, category);
        }
    }
}
