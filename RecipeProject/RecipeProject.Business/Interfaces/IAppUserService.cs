using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Interfaces
{
    public interface IAppUserService
    {
        Task<List<AppUser>> GetAllAsync();
        Task<AppUser> FindByIdAsync(string id);
        Task<AppUser> FindByUserNameAsync(string userName);
        Task AddAsync(AppUser appUser);
        Task UpdateAsync(string id, AppUser appUser);
        Task RemoveAsync(string id);
    }
}
