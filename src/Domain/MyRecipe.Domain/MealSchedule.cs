
namespace MyRecipe.Domain
{
    /// <summary>
    /// Расписание приёмов пищи.
    /// </summary>
    public class MealSchedule
    {
        /// <summary>
        /// Идентификатор расписания приёмов пищи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название расписания приёмов пищи.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание расписания приёмов пищи.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Приёмы пищи.
        /// </summary>
        public virtual IEnumerable<Meal> Meals { get; set; }
    }
}
