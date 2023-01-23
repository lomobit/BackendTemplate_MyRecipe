namespace MyRecipe.Domain
{
    public class Ingredient
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
        /// Описание расписания приёмов пищи.
        /// </summary>
        public string? Description { get; set; }
    }
}