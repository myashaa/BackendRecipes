using BackendRecipes.Api.Dto;
using BackendRecipes.Api.Сonverters;
using BackendRecipes.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendRecipes.Api.Controllers
{
    [Route( "" )]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;
        private IRecipeConverter _recipeConverter;
        public RecipeController(IRecipeService recipeService, IRecipeConverter recipeConverter)
        {
            _recipeService = recipeService;
            _recipeConverter = recipeConverter;
        }

        [HttpGet]
        [Route( "recipes" )]
        public IActionResult GetAllRecipes()
        {
            List<RecipeDto> recipes = _recipeService.GetRecipes().ConvertAll(r => _recipeConverter.ConvertToRecipeDto(r));
            return Ok( recipes );
        }

        [HttpGet]
        [Route("recipe/{id:long}")]
        public IActionResult GetRecipeById( long id )
        {
            RecipeDto recipe = _recipeConverter.ConvertToRecipeDto(_recipeService.GetRecipe(id));
            return Ok( recipe );
        }
    }
}
