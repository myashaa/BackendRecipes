using System.Collections.Generic;
using System.Linq;

namespace BackendRecipes.Domain.Recipe
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepository;

        public RecipeService( IRecipeRepository recipeRepository )
        {
            _recipeRepository = recipeRepository;
        }

        public List<Recipe> GetRecipes()
        {
            var recipes = _recipeRepository.GetAll();
            return recipes.ToList();
        }

        public Recipe GetRecipe( long id )
        {
            var recipe = _recipeRepository.GetById(id);
            return recipe;
        }

        public List<Recipe> SearchRecipes( string category, string searchText )
        {
            var recipes = _recipeRepository.SearchAll(category, searchText);
            return recipes.ToList();
        }

        public Recipe GetFavoriteRecipe()
        {
            var recipe = _recipeRepository.GetFavorite();
            return recipe;
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipeRepository.AddNew(recipe);
        }

        public void DeleteRecipe( long id )
        {
            _recipeRepository.DeleteCurrent(id);
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _recipeRepository.UpdateCurrent(recipe);
        }
    }
}
