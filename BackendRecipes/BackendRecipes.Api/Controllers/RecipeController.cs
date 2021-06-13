using BackendRecipes.Api.Dto;
using BackendRecipes.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendRecipes.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;
        public RecipeController( IRecipeService recipeService )
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [Route( "" )]
        public IActionResult GetAllRecipes()
        {
            List<RecipeDto> recipes = _recipeService.GetRecipes().ConvertAll(x => ConvertToRecipeDto(x));
            RecipeDto ConvertToRecipeDto(Recipe recipe)
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
            IngredientDto ConvertToIngredientDto(Ingredient ingredient)
            {
                return new IngredientDto
                {
                    Title = ingredient.Title,
                    Items = ingredient.Items
                };
            }
            StepDto ConvertToStepDto(Step step)
            {
                return new StepDto
                {
                    Number = step.Number,
                    Description = step.Description
                };
            }
            return Ok( recipes );
        }
    }
}
