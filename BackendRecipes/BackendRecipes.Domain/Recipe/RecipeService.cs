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
    }
}
