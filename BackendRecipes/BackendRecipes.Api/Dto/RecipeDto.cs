using System.Collections.Generic;

namespace BackendRecipes.Api.Dto
{
    public class RecipeDto
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string[] Tags { get; set; }
        public long Favorites { get; set; }
        public long Likes { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CookingTimeInMinutes { get; set; }
        public long TotalPersons { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public List<StepDto> Steps { get; set; } 
    }
}
