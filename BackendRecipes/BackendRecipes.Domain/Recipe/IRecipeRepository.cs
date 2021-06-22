using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById( long id );

        void Add( Recipe recipe );
    }
}
