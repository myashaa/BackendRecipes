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
                    Id = 1,
                    ImageUrl = "",
                    Author = "glazest",
                    Tags = "десерты, клубника, сливки",
                    Favorites = 10,
                    Likes = 8,
                    Name = "Клубничная панна-котта",
                    Description = "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.",
                    CookingTimeInMinutes = 35,
                    TotalPersons = 5
                    //Ingredients = new List<Ingredient>(),
               //     Steps = new List<Step>()
                },
                new Recipe
                {
                    Id = 2,
                    ImageUrl = "",
                    Author = "horilka",
                    Tags = "вторые блюда, мясо, соевый соус",
                    Favorites = 4,
                    Likes = 7,
                    Name = "Мясные фрикадельки",
                    Description = "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.",
                    CookingTimeInMinutes = 90,
                    TotalPersons = 4
                  //  Ingredients = new List<Ingredient>(),
                  //  Steps = new List<Step>()
                }
            };
        }
    }
}
