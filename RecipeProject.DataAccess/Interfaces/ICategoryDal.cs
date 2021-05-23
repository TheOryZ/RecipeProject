using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.DataAccess.Interfaces
{
    public interface ICategoryDal
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> FindByIdAsync(string id);
        Task AddAsync(Category category);
        Task UpdateAsync(string id, Category category);
        Task RemoveAsync(string id);
    }
}
