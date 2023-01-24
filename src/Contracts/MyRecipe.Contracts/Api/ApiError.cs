
namespace MyRecipe.Contracts.Api
{
    public class ApiError
    {
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Идентификатор запроса.
        /// </summary>
        public string TraceId { get; set; }
    }
}
