using BackendRecipes.Api.Dto;
using BackendRecipes.Domain.Recipe;

namespace BackendRecipes.Api.Сonverters
{
    public interface IRecipeConverter
    {
        RecipeDto ConvertToRecipeDto(Recipe recipe);
        Recipe ConvertToRecipe(RecipeDto recipeDto);
    }
}
