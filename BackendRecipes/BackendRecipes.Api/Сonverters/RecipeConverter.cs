using BackendRecipes.Api.Dto;
using BackendRecipes.Domain.Recipe;

namespace BackendRecipes.Api.Сonverters
{
    public class RecipeConverter: IRecipeConverter
    {
        public RecipeDto ConvertToRecipeDto(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                ImageUrl = recipe.ImageUrl,
                Author = recipe.Author,
                Tags = recipe.Tags,
                Favorites = recipe.Favorites,
                Likes = recipe.Likes,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTimeInMinutes = recipe.CookingTimeInMinutes,
                TotalPersons = recipe.TotalPersons,
                Ingredients = recipe.Ingredients.ConvertAll(x => ConvertToIngredientDto(x)),
                Steps = recipe.Steps.ConvertAll(x => ConvertToStepDto(x))
            };
        }
        private IngredientDto ConvertToIngredientDto(Ingredient ingredient)
        {
            return new IngredientDto
            {
                Title = ingredient.Title,
                Items = ingredient.Items
            };
        }
        private StepDto ConvertToStepDto(Step step)
        {
            return new StepDto
            {
                Number = step.Number,
                Description = step.Description
            };
        }
    }
}
