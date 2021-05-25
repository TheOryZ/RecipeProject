using System;

namespace RecipeProject.WebUI.Models
{
    public class RecipeList
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CategoryId { get; set; }
        public CategoryList Category { get; set; }
    }
}