using RecipeProject.Business.Interfaces;
using RecipeProject.Core.StringInfos;
using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeProject.WebAPI
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService)
        {
            var adminRole = await appUserService.FindByAdminAsync(RoleInfos.Admin);
            if(adminRole == null)
            {
                await appUserService.AddAsync(new AppUser
                {
                    Name = "John Doe",
                    UserName = "TheOryZ",
                    Password = "0",
                    AppRole = new AppRole { RoleName = "Admin" }
                });
            }
        }
    }
}
