using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById( long id );
        IEnumerable<Recipe> SearchAll( string category, string searchText );
        void AddNew( Recipe recipe );
    }
}
