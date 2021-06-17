using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BackendRecipes.Infrastructure.Context
{
    public class DesignTimeRepositoryContextFactory
    {
        public BackendRecipesDbContext CreateDbContext( string[] args )
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json" )
                .AddJsonFile( $"appsettings.{Environment.GetEnvironmentVariable( "ASPNETCORE_ENVIRONMENT" )}.json", true )
                .AddEnvironmentVariables();

            var config = builder.Build();
            var connectionString = config.GetConnectionString( "DefaultConnection" );
            var optionsBuilder = new DbContextOptionsBuilder<BackendRecipesDbContext>();
            optionsBuilder.UseSqlServer( connectionString );

            return new BackendRecipesDbContext( optionsBuilder.Options );
        }
    }
}
