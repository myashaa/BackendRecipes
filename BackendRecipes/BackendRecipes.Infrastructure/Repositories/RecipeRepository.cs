using BackendRecipes.Domain.Recipe;
using BackendRecipes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackendRecipes.Infrastructure.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository( BackendRecipesDbContext dbContext )
            :base( dbContext )
        {
        }

        public IEnumerable<Recipe> GetAll()
        {
            return Entities
                .Include( r => r.Ingredients )
                .ToList();
        }

        public List<Recipe> GetById( string name )
        {
            return Entities.Where( e => e.Name.Contains( name ) ).ToList();
        }
    }
}
