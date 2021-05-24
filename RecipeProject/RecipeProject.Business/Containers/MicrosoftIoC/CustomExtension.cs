using Microsoft.Extensions.DependencyInjection;
using RecipeProject.Business.Concrete;
using RecipeProject.Business.Interfaces;
using RecipeProject.DataAccess.Concrete.Repositories;
using RecipeProject.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Containers.MicrosoftIoC
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDal, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IRecipeDal, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeManager>();
            services.AddScoped<IAppUserDal, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IJwtService, JwtManager>();
        }
    }
}
