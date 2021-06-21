using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRecipes.Domain.Recipe
{
    public class Step
    {
        public long Id { get; set; }
        public long RecipeId { get; set; }
        public long Number { get; set; }
        public string Description { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
    }
}
