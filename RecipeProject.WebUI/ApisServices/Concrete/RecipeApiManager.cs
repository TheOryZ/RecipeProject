using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RecipeProject.WebUI.ApiServices.Interfaces;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.ApiServices.Concrete
{
    public class RecipeApiManager : IRecipeApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RecipeApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<RecipeList>> GetAllAsync()
        {
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("http://localhost:7538/api/Recipes");
            if(responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<RecipeList>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<RecipeList> GetByIdAsync(string id)
        {
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync($"http://localhost:7538/api/Recipes/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<RecipeList>(await responseMessage.Content.ReadAsStringAsync());
                return product;
            }
            return null;
        }

        public async Task AddAsync(RecipeAdd recipeAdd)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if(!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(recipeAdd);
                var stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
                var responseMessage = await httpClient.PostAsync("http://localhost:7538/api/Recipes",stringContent);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if(!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                await httpClient.DeleteAsync($"http://localhost:7538/api/Recipes/{id}");
            }
        }

        public async Task UpdateAsync(string id, RecipeUpdate recipeUpdate)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("token");
            if(!string.IsNullOrWhiteSpace(token))
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(recipeUpdate);
                var stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
                await httpClient.PutAsync("http://localhost:7538/api/Recipes", stringContent);
            }
        }
    }
}