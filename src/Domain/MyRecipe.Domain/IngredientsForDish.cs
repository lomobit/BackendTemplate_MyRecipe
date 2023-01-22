
namespace MyRecipe.Domain
{
    public class IngredientsForDish
    {
        /// <summary>
        /// Идентификатор записи ингредиента для блюда
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор ингредиента
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Ингредиент
        /// </summary>
        public virtual Ingredient Ingredient { get; set; }

        /// <summary>
        /// Идентификатор блюда
        /// </summary>
        public int DishId { get; set; }

        /// <summary>
        /// Блюдо
        /// </summary>
        public virtual Dish Dish { get; set; }

        /// <summary>
        /// Количество ингредиента для блюда
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Код ОКЕИ (код единицы измерения)
        /// </summary>
        public string OkeiCode { get; set; }

        /// <summary>
        /// ОКЕИ (единица измерения)
        /// </summary>
        public virtual Okei Okei { get; set; }

        /// <summary>
        /// Состояние ингридиента в блюде
        /// </summary>
        public string? Condition { get; set; }
    }
}
