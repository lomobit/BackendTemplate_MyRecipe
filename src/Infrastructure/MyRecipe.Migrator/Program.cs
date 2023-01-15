using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyRecipe.Infrastructure;
using MyRecipe.Migrator;


await CreateHostBuilder(args)
    .RunConsoleAsync(options => options.SuppressStatusMessages = true);

static IHostBuilder CreateHostBuilder(string[] args) =>
    new HostBuilder()
        .ConfigureAppConfiguration((hostContext, configApp) =>
        {
            configApp.SetBasePath(Directory.GetCurrentDirectory());
            configApp.AddJsonFile("appsettings.json");
            configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json");
            configApp.AddCommandLine(args);
            configApp.AddEnvironmentVariables();
        })
        .ConfigureServices((hostContext, services) =>
        {
            var connectionString = hostContext.Configuration.GetConnectionString("MyRecipeDb");

            services.AddDbContext<MyRecipeDbContext>();
            services.AddHostedService<MigrationsWorker>();
        });
