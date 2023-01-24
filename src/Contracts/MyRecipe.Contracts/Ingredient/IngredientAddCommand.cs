
namespace MyRecipe.Contracts.Ingredient
{
    public class IngredientAddCommand
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
