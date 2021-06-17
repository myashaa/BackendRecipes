using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRecipes.Domain.Recipe
{
    public class Ingredient
    {
        public long Id { get; set; }
        public long RecipeId { get; set; }
        public string Title { get; set; }
        public string Items { get; set; }
        [ForeignKey( "RecipeId" )]
        public Recipe Recipe { get; set; }
    }
}
