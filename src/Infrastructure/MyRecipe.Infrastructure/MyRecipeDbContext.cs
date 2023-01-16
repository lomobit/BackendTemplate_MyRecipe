using Microsoft.EntityFrameworkCore;
using MyRecipe.Domain;
using MyRecipe.Domain.Configurations;

namespace MyRecipe.Infrastructure;

public class MyRecipeDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }


    public MyRecipeDbContext(DbContextOptions<MyRecipeDbContext> options) : base(options)
	{
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
    }
}