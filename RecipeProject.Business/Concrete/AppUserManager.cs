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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public async Task AddAsync(AppUser appUser)
        {
            await _appUserDal.AddAsync(appUser);
        }

        public async Task<AppUser> FindByIdAsync(string id)
        {
            return await _appUserDal.FindByIdAsync(id);
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _appUserDal.GetAllAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _appUserDal.RemoveAsync(id);
        }

        public async Task UpdateAsync(string id, AppUser appUser)
        {
            await _appUserDal.UpdateAsync(id, appUser);
        }
    }
}
