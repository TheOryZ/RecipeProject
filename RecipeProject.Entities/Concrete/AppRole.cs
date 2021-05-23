using RecipeProject.Entities.Interfaces;

namespace RecipeProject.Entities.Concrete
{
    public class AppRole : ITable
    {
        public string RoleName { get; set; }
    }
}
