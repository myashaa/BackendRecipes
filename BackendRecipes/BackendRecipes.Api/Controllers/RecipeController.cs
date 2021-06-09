using BackendRecipes.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_recipeService.GetRecipes() );
        }
    }
}
