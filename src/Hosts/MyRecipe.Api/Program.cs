using AppServices.Ingredient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipe.Handlers;
using MyRecipe.Infrastructure;
using MyRecipe.Infrastructure.Repositories.Ingredient;

// ������ ������ ��������, ��� ��� ����������� - ��� API-�����������
[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(MediatREntrypoint).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� DbContext'�
builder.Services.AddDbContext<MyRecipeDbContext>((IServiceProvider sp, DbContextOptionsBuilder dbOptions) =>
{
    const string connectionStringName = "MyRecipeDb";

    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    var configuration = sp.GetRequiredService<IConfiguration>();

    var connectionString = configuration.GetConnectionString(connectionStringName);
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException($"�� ������� ������ ����������� � ������ {connectionStringName}");
    }

    dbOptions
        .UseLazyLoadingProxies()
        .UseLoggerFactory(loggerFactory)
        .UseNpgsql(connectionString);

}, ServiceLifetime.Singleton);

// ���������� �������� ����������
builder.Services.AddScoped<IIngredientService, IngredientService>();

// ���������� ������������ ��� ������ � ����� ������
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();

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
