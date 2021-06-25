﻿using BackendRecipes.Api.Dto;
using BackendRecipes.Api.Сonverters;
using BackendRecipes.Domain.Abstractions;
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
        private IUnitOfWork _unitOfWork;
        public RecipeController(IRecipeService recipeService, IRecipeConverter recipeConverter, IUnitOfWork unitOfWork)
        {
            _recipeService = recipeService;
            _recipeConverter = recipeConverter;
            _unitOfWork = unitOfWork;
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

        [HttpGet]
        [Route("recipes/{category}/{searchText}")]
        public IActionResult SearchAllRecipes( string category, string searchText )
        {
            List<RecipeDto> recipes = _recipeService.SearchRecipes(category, searchText).ConvertAll(r => _recipeConverter.ConvertToRecipeDto(r));
            return Ok(recipes);
        }

        [HttpPost]
        [Route("added")]
        public IActionResult AddRecipe([FromBody] RecipeDto recipeDto)
        {
            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto);
            _recipeService.AddRecipe(recipe);
            _unitOfWork.Commit();
            return Ok();
        }
    }
}
