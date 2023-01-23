
namespace MyRecipe.Domain
{
    public class Dish
    {
        /// <summary>
        /// Идентификатор блюда.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование блюда.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// На какое количество человек
        /// </summary>
        public int NumberOfPersons { get; set; }
    }
}
