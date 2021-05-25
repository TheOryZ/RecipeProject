using System.ComponentModel.DataAnnotations;

namespace RecipeProject.WebUI.Models
{
    public class AppUserLogin
    {
        [Required(ErrorMessage="Username field cannot be blank.")]
        [Display(Name="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Password field cannot be blank.")]
        [Display(Name="Password")]
        public string Password { get; set; }
    }
}