using MyRecipe.Contracts.Enums;

namespace MyRecipe.Domain
{
    public class Meal
    {
        /// <summary>
        /// Идентификатор приёма пищи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование приёма пищи.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание расписания приёмов пищи.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата и время приёма пищи.
        /// </summary>
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// Тип приёма пищи.
        /// </summary>
        public MealTypeEnum MealType { get; set; }

        /// <summary>
        /// Блюда приёма пищи.
        /// </summary>
        public virtual IEnumerable<Dish> Dishes { get; set; }
    }
}
