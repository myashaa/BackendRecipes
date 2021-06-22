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
                .Include(r => r.Steps)
                .ToList();
        }

        public Recipe GetById( long id )
        {
            return Entities
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> SearchAll( string category, string searchText )
        {
            if (category == "name") { 
            return Entities
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .Where(r => r.Name == searchText)
                .ToList();
            }
            if (category == "tag")
            {
                return Entities
                    .Include(r => r.Ingredients)
                    .Include(r => r.Steps)
                    .Where(r => r.Tags == searchText)
                    .ToList();
            }
            if (category == "author")
            {
                return Entities
                    .Include(r => r.Ingredients)
                    .Include(r => r.Steps)
                    .Where(r => r.Author == searchText)
                    .ToList();
            }
            return null;
        }
    }
}
