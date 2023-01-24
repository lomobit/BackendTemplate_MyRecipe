using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipe.Infrastructure;

// Задаем сборке аттрибут, что все контроллеры - это API-контроллеры
[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyRecipeDbContext>((IServiceProvider sp, DbContextOptionsBuilder dbOptions) =>
{
    const string connectionStringName = "MyRecipeDb";

    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    var configuration = sp.GetRequiredService<IConfiguration>();

    var connectionString = configuration.GetConnectionString(connectionStringName);
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException(
            $"Не найдена строка подключения с именем {connectionStringName}");
    }

    dbOptions
        .UseLazyLoadingProxies()
        .UseLoggerFactory(loggerFactory)
        .UseNpgsql(connectionString);

}, ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
