using BackendRecipes.Api.Dto;
using BackendRecipes.Api.Сonverters;
using BackendRecipes.Domain.Abstractions;
using BackendRecipes.Domain.Recipe;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackendRecipes.Api.Controllers
{
    [EnableCors("TheCodePolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;
        private IRecipeConverter _recipeConverter;
        private IUnitOfWork _unitOfWork;
        public RecipeController(IRecipeService recipeService, IRecipeConverter recipeConverter, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _recipeConverter = recipeConverter;
            _unitOfWork = unitOfWork;
        }   

        [HttpGet]
        [Route( "" )]
        public IActionResult GetAllRecipes()
        {
            List<RecipeDto> recipes = _recipeService.GetRecipes().ConvertAll(r => _recipeConverter.ConvertToRecipeDto(r));
            return Ok( recipes );
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetRecipeById( long id )
        {
            RecipeDto recipe = _recipeConverter.ConvertToRecipeDto(_recipeService.GetRecipe(id));
            return Ok( recipe );
        }

        [HttpGet]
        [Route("{category}/{searchText}")]
        public IActionResult SearchAllRecipes( string category, string searchText )
        {
            List<RecipeDto> recipes = _recipeService.SearchRecipes(category, searchText).ConvertAll(r => _recipeConverter.ConvertToRecipeDto(r));
            return Ok(recipes);
        }

        [HttpPost]
        [Route("/add")]
        public IActionResult AddRecipe([FromBody] RecipeDto recipeDto)
        {
            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto);
            _recipeService.AddRecipe(recipe);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
