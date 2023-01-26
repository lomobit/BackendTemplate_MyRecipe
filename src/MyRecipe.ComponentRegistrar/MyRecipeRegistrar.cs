using AppServices.Ingredient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyRecipe.Infrastructure;
using MyRecipe.Infrastructure.Repositories.Ingredient;
using MyRecipe.Logging.Loggers;
using MyRecipeLogging.Infrastructure;

namespace MyRecipe.ComponentRegistrar
{
    public static class MyRecipeRegistrar
    {
        /// <summary>
        /// Добавление зависимостей для MyRecipe.
        /// </summary>
        /// <param name="services">Коллекция сервисов DI.</param>
        /// <returns>Коллекция сервисов DI.</returns>
        public static IServiceCollection AddMyRecipe(this IServiceCollection services)
        {
            // Добавление DbContext'ов
            services.AddMyRecipeDbContexts();

            // Добавление сервисов приложения
            services.AddMyRecipeServices();

            // Добавление репозиториев для работы с базой данных
            services.AddMyRecipeRepositories();

            // Добавление логгеров
            services.AddMyRecipeLoggers();

            return services;
        }

        /// <summary>
        /// Добавление DbContext'ов.
        /// </summary>
        /// <param name="services">Коллекция сервисов DI.</param>
        /// <returns>Коллекция сервисов DI.</returns>
        public static IServiceCollection AddMyRecipeDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<MyRecipeDbContext>(AddMyRecipeDbContext, ServiceLifetime.Singleton);
            services.AddDbContext<MyRecipeLoggingDbContext>(AddMyRecipeLoggingDbContext, ServiceLifetime.Singleton);

            return services;
        }

        /// <summary>
        /// Добавление сервисов приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов DI.</param>
        /// <returns>Коллекция сервисов DI.</returns>
        public static IServiceCollection AddMyRecipeServices(this IServiceCollection services)
        {
            services.AddScoped<IIngredientService, IngredientService>();

            return services;
        }

        /// <summary>
        /// Добавление репозиториев для работы с базой данных.
        /// </summary>
        /// <param name="services">Коллекция сервисов DI.</param>
        /// <returns>Коллекция сервисов DI.</returns>
        public static IServiceCollection AddMyRecipeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            return services;
        }

        /// <summary>
        /// Добавление логгеров.
        /// </summary>
        /// <param name="services">Коллекция сервисов DI.</param>
        /// <returns>Коллекция сервисов DI.</returns>
        public static IServiceCollection AddMyRecipeLoggers(this IServiceCollection services)
        {
            services.AddScoped<ILogger, DbLogger>();

            return services;
        }

        /// <summary>
        /// Метод <see cref="Action"/>'а для добавления контекста базы данных MyRecipe в коллекцию сервисов DI.
        /// </summary>
        /// <param name="sp">Провайдер сервисов.</param>
        /// <param name="dbOptions">Опции для построения конекста базы данных.</param>
        private static void AddMyRecipeDbContext(IServiceProvider sp, DbContextOptionsBuilder dbOptions)
        {
            AddDbContextAction("MyRecipeDb", sp, dbOptions);
        }

        /// <summary>
        /// Метод <see cref="Action"/>'а для добавления контекста базы данных MyRecipeLogging в коллекцию сервисов DI.
        /// </summary>
        /// <param name="sp">Провайдер сервисов.</param>
        /// <param name="dbOptions">Опции для построения конекста базы данных.</param>
        private static void AddMyRecipeLoggingDbContext(IServiceProvider sp, DbContextOptionsBuilder dbOptions)
        {
            AddDbContextAction("MyRecipeLoggingDb", sp, dbOptions);
        }

        /// <summary>
        /// Метод <see cref="Action"/>'а для добавления контекста базы данных в коллекцию сервисов DI.
        /// </summary>
        /// <param name="connectionStringName">Название строки подключения.</param>
        /// <param name="sp">Провайдер сервисов.</param>
        /// <param name="dbOptions">Опции для построения конекста базы данных.</param>
        /// <exception cref="InvalidOperationException">Не найдена строка подключения.</exception>
        private static void AddDbContextAction(string connectionStringName, IServiceProvider sp, DbContextOptionsBuilder dbOptions)
        {
            var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Не найдена строка подключения с именем {connectionStringName}");
            }

            dbOptions
                .UseLazyLoadingProxies()
                //.UseLoggerFactory(sp.GetRequiredService<ILoggerFactory>())
                .UseNpgsql(connectionString);
        }
    }
}