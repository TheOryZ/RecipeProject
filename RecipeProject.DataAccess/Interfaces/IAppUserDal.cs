using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        Task<List<AppUser>> GetAllAsync();
        Task<AppUser> FindByIdAsync(string id);
        Task AddAsync(AppUser appUser);
        Task UpdateAsync(string id, AppUser appUser);
        Task RemoveAsync(string id);
    }
}
