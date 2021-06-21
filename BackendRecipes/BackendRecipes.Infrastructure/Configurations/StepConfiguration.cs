using BackendRecipes.Domain.Recipe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendRecipes.Infrastructure.Configurations
{
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure( EntityTypeBuilder<Step> builder )
        {
            builder.ToTable( nameof( Step ) ).HasKey( t => t.Id );
            builder
                .HasOne( s => s.Recipe )
                .WithMany( r => r.Steps )
                .HasForeignKey( s => s.RecipeId );
        }
    }
}
