using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById( long id );
        IEnumerable<Recipe> SearchAll( string category, string searchText );
        Recipe GetFavorite();
        void AddNew( Recipe recipe );
        void DeleteCurrent( long id );
        void UpdateCurrent(Recipe recipe);
    }
}
