using System.Collections.Generic;

namespace BackendRecipes.Domain.Recipe
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes();
    }
}
