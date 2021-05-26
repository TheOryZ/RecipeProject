using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RecipeProject.WebUI.ApiServices.Interfaces;
using RecipeProject.WebUI.Models;

namespace RecipeProject.WebUI.ApiServices.Concrete
{
    public class CategoryApiManager : ICategoryApiService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryApiManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<CategoryListModel>> GetAllAsync()
        {
            using var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("http://localhost:7538/api/Categories");
            if(responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<CategoryListModel>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}