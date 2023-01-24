
using MediatR;
using MyRecipe.Contracts.Ingredient;

namespace MyRecipe.Handlers.Ingredient
{
    public class IngredientAddCommandHandler : IRequestHandler<IngredientAddCommand, IngredientDto>
    {
        public async Task<IngredientDto> Handle(IngredientAddCommand request, CancellationToken cancellationToken)
        {
            return new IngredientDto()
            {
                Id = new Random().Next(),
                Name = request.Name,
                Description = request.Description,
            };
        }
    }
}
