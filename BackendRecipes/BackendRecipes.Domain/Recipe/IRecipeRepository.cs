using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();

        void Add( Recipe recipe );
    }
}
