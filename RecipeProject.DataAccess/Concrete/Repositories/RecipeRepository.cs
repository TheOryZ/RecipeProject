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
    public class RecipeRepository : IRecipeDal
    {
        private readonly IMongoCollection<Recipe> _recipeCollection;
        public RecipeRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _recipeCollection = database.GetCollection<Recipe>(databaseSettings.CategoryCollectionName);
        }
        public async Task AddAsync(Recipe recipe)
        {
            await _recipeCollection.InsertOneAsync(recipe);
        }

        public async Task<Recipe> FindByIdAsync(string id)
        {
            return await _recipeCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _recipeCollection.Find(x => true).ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _recipeCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, Recipe recipe)
        {
            await _recipeCollection.ReplaceOneAsync(x => x.Id == id, recipe);
        }
    }
}
