using BackendRecipes.Domain.Abstractions;
using BackendRecipes.Api.Ņonverters;
using BackendRecipes.Domain.Recipe;
using BackendRecipes.Infrastructure.Context;
using BackendRecipes.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackendRecipes.Api
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<BackendRecipesDbContext>>();
            services.AddDbContext<BackendRecipesDbContext>( c => 
                c.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) )
            );
            services.AddScoped<IRecipeConverter, RecipeConverter>();
           // services.AddSingleton<IRecipeRepository, MemoryRecipeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );
        }
    }
}
