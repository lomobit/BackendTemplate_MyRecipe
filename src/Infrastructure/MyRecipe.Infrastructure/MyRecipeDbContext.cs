using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyRecipe.Domain;
using MyRecipe.Domain.Configurations;

namespace MyRecipe.Infrastructure;

public class MyRecipeDbContext : DbContext
{
    private const string ConnectionStringName = "MyRecipeDb";

    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public DbSet<Ingredient> Ingredients { get; set; }


    public MyRecipeDbContext(IConfiguration configuration, ILoggerFactory loggerFactory)
	{
        _configuration = configuration;
        _loggerFactory = loggerFactory;

        // TODO: удалить после первого релиза
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString(ConnectionStringName);
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{ConnectionStringName}'");

        optionsBuilder.UseLazyLoadingProxies()
            .UseLoggerFactory(_loggerFactory)
            .UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IngredientConfiguration());
    }
}