
using MyRecipe.Contracts.Ingredient;

namespace MyRecipe.Infrastructure.Repositories.Ingredient
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MyRecipeDbContext _context;

        public IngredientRepository(MyRecipeDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<int> AddAsync(IngredientDto ingredientDto, CancellationToken cancellationToken)
        {
            await _context.Ingredients.AddAsync(new Domain.Ingredient
            {
                Name = ingredientDto.Name,
                Description = ingredientDto.Description,
            }, cancellationToken);
            await _context.SaveChangesAsync();

            return _context.Ingredients
                .Where(x => x.Name == ingredientDto.Name)
                .Select(x => x.Id)
                .First();
        }
    }
}
