using BackendRecipes.Domain.Recipe;
using BackendRecipes.Infrastructure.Constans;
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
            switch (category)
            {
                case SearchConstans.name:
                    return Entities
                        .Include(r => r.Ingredients)
                        .Include(r => r.Steps)
                        .Where(r => r.Name == searchText)
                        .ToList();
                case SearchConstans.tag:
                    return Entities
                        .Include(r => r.Ingredients)
                        .Include(r => r.Steps)
                        .Where(r => r.Tags.Contains(searchText))
                        .ToList();
                case SearchConstans.author:
                    return Entities
                        .Include(r => r.Ingredients)
                        .Include(r => r.Steps)
                        .Where(r => r.Author == searchText)
                        .ToList();
                default:
                    break;
            }
            return null;
        }

        public Recipe GetFavorite()
        {
            var maxValue = Entities.Max(r => r.Likes);
            return Entities
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .FirstOrDefault(r => r.Likes == maxValue);
        }

        public void AddNew(Recipe recipe)
        {
            Add(recipe);
        }

        public void DeleteCurrent( long id )
        {
            var recipe = Entities
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .FirstOrDefault(r => r.Id == id);
            Delete(recipe);
        }
    }
}
