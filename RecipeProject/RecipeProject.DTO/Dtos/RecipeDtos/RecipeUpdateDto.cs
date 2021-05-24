namespace RecipeProject.DTO.Dtos.RecipeDtos
{
    public class RecipeUpdateDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public string CategoryId { get; set; }
    }
}
