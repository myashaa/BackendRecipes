using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipe( long id );
        List<Recipe> SearchRecipes( string category, string searchText );
        Recipe GetFavoriteRecipe();
        void AddRecipe(Recipe recipe);
        void DeleteRecipe( long id );
    }
}
