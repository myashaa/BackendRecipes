using BackendRecipes.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BackendRecipes.Infrastructure.Context
{
    public class BackendRecipesDbContext : DbContext
    {
        public BackendRecipesDbContext( DbContextOptions<BackendRecipesDbContext> options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new RecipeConfiguration() );
            modelBuilder.ApplyConfiguration( new IngredientConfiguration() );
            modelBuilder.ApplyConfiguration(new StepConfiguration());
        }
    }
} 
