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
                Ingredients = recipe.Ingredients.ConvertAll(r => ConvertToIngredientDto(r)),
                Steps = recipe.Steps.ConvertAll(r => ConvertToStepDto(r))
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
        public Recipe ConvertToRecipe(RecipeDto recipeDto)
        {
            return new Recipe
            {
                Id = recipeDto.Id,
                ImageUrl = recipeDto.ImageUrl,
                Author = recipeDto.Author,
                Tags = recipeDto.Tags,
                Favorites = recipeDto.Favorites,
                Likes = recipeDto.Likes,
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                CookingTimeInMinutes = recipeDto.CookingTimeInMinutes,
                TotalPersons = recipeDto.TotalPersons,
                Ingredients = recipeDto.Ingredients.ConvertAll(r => ConvertToIngredient(r)),
                Steps = recipeDto.Steps.ConvertAll(r => ConvertToStep(r))
            };
        }
        private Ingredient ConvertToIngredient(IngredientDto ingredientDto)
        {
            return new Ingredient
            {
                Title = ingredientDto.Title,
                Items = ingredientDto.Items
            };
        }
        private Step ConvertToStep(StepDto stepDto)
        {
            return new Step
            {
                Number = stepDto.Number,
                Description = stepDto.Description
            };
        }
    }
}
