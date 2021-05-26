using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecipeProject.WebUI.ApiServices.Concrete;
using RecipeProject.WebUI.ApiServices.Interfaces;

namespace RecipeProject.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryApiService, CategoryApiManager>();
            services.AddScoped<IRecipeApiService, RecipeApiManager>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(name:"areas", pattern:"{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
