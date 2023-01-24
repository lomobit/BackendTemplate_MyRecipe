
using MediatR;
using MyRecipe.Contracts.Ingredient;

namespace MyRecipe.Handlers.Ingredient
{
    public class IngredientAddCommand : IRequest<IngredientDto>
    {
        /// <summary>
        /// Наименование ингридиента.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание ингредиента.
        /// </summary>
        public string? Description { get; set; }
    }
}
