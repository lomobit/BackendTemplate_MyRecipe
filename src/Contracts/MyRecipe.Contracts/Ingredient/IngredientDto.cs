
namespace MyRecipe.Contracts.Ingredient
{
    public class IngredientDto
    {
        /// <summary>
        /// Идентификатор ингридиента.
        /// </summary>
        public int Id { get; set; }

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
