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
    public class CategoryRepository : ICategoryDal
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryCollection.Find(x => true).ToListAsync();
        }
        public async Task<Category> FindByIdAsync(string id)
        {
            return await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
        }
        public async Task UpdateAsync(string id, Category category)
        {
            await _categoryCollection.ReplaceOneAsync(x => x.Id == id, category);
        }
        public async Task RemoveAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
