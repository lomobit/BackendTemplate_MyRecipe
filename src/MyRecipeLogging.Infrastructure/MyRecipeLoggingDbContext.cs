
using Microsoft.EntityFrameworkCore;

namespace MyRecipeLogging.Infrastructure
{
    public class MyRecipeLoggingDbContext : DbContext
    {

        public MyRecipeLoggingDbContext(DbContextOptions<MyRecipeLoggingDbContext> options) : base(options)
        {
            // TODO: необходимо применять миграции до запуска приложения
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new IngredientConfiguration());
        }
    }
}
