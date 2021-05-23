using RecipeProject.DTO.Dtos.CategoryDtos;
using System;

namespace RecipeProject.DTO.Dtos.RecipeDtos
{
    public class RecipeListDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CategoryId { get; set; }
        public CategoryListDto Category { get; set; }
    }
}
