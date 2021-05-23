using RecipeProject.DTO.Dtos.AppRoleDtos;

namespace RecipeProject.DTO.Dtos.AppUserDtos
{
    public class AppUserAddDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public AppRoleListDto AppRole { get; set; }
    }
}
