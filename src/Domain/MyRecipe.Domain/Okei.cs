
namespace MyRecipe.Domain
{
    /// <summary>
    /// Общероссийский классификатор единиц измерения
    /// </summary>
    public class Okei
    {
        /// <summary>
        /// Код ОКЕИ (единицы измерения)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование единицы измерения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Условное обозначение (национальное)
        /// </summary>
        public string? ConventionDesignationNational { get; set; }

        /// <summary>
        /// Условное обозначение (международное)
        /// </summary>
        public string? ConventionDesignationInternational { get; set; }

        /// <summary>
        /// Кодовое обозначение (национальное)
        /// </summary>
        public string? CodeDesignationNational { get; set; }

        /// <summary>
        /// Кодовое обозначение (международное)
        /// </summary>
        public string? CodeDesignationInternational { get; set; }

    }
}
