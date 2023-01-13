using Microsoft.EntityFrameworkCore;
using MyRecipe.Domain;

namespace MyRecipe.Infrastructure;

public class MyRecipeDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }


    public MyRecipeDbContext()
	{
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=host.docker.internal;Port=32768;Database=usersdb;Username=postgres;Password=postgrespw");
    }
}