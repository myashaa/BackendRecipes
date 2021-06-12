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
                    Name = recipe.Name,
                    Description = recipe.Description,
                    Id = recipe.Id,
                    ImageUrl = recipe.ImageUrl
                };
            }
            return Ok( recipes );
        }
    }
}
