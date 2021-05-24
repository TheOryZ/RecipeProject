using MongoDB.Driver;
using RecipeProject.Core.Settings;
using RecipeProject.DataAccess.Interfaces;
using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.DataAccess.Concrete.Repositories
{
    public class AppUserRepository : IAppUserDal
    {
        private readonly IMongoCollection<AppUser> _appUserCollection;
        public AppUserRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _appUserCollection = database.GetCollection<AppUser>(databaseSettings.AppUserCollectionName);
        }
        public async Task AddAsync(AppUser appUser)
        {
            await _appUserCollection.InsertOneAsync(appUser);
        }

        public async Task<AppUser> FindByIdAsync(string id)
        {
            return await _appUserCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            return await _appUserCollection.Find(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _appUserCollection.Find(x => true).ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _appUserCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, AppUser appUser)
        {
            await _appUserCollection.ReplaceOneAsync(x => x.Id == id, appUser);
        }
    }
}
