using BackendRecipes.Api.Dto;
using BackendRecipes.Api.Сonverters;
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
        private IRecipeConverter _recipeConverter;
        public RecipeController(IRecipeService recipeService, IRecipeConverter recipeConverter)
        {
            _recipeService = recipeService;
            _recipeConverter = recipeConverter;
        }

        [HttpGet]
        [Route( "" )]
        public IActionResult GetAllRecipes()
        {
            List<RecipeDto> recipes = _recipeService.GetRecipes().ConvertAll(x => _recipeConverter.ConvertToRecipeDto(x));
            return Ok( recipes );
        }
    }
}
