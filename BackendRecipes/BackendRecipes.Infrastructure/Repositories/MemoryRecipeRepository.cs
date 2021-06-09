using BackendRecipes.Domain.Recipe;
using System.Collections.Generic;

namespace BackendRecipes.Infrastructure.Repositories
{
    public class MemoryRecipeRepository : MemoryRepository<Recipe>, IRecipeRepository
    {
        public MemoryRecipeRepository()
        {
            _table = new List<Recipe>
            { 
                new Recipe 
                {
                    Name = "Мороженное",
                    Description = "Вкусное ом-ом-ом",
                    Id = 0,
                    ImageUrl = ""
                },
                new Recipe
                {
                    Name = "Мороженное",
                    Description = "Вкусное ом-ом-ом",
                    Id = 1,
                    ImageUrl = ""
                }
            };
        }
    }
}
