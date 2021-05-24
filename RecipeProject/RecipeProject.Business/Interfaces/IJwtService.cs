using RecipeProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeProject.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser appUser, AppRole appRole);
    }
}
