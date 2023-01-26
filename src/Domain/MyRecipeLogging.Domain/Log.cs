using MyRecipe.Contracts.Enums.Log;

namespace MyRecipeLogging.Domain
{
    public class Log
    {
        /// <summary>
        /// Время записи лога.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Сообщение лога.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Тип сообщения.
        /// </summary>
        public LogMessageTypeEnum MessageType { get; set; }

        /// <summary>
        /// Трассировка стека.
        /// </summary>
        public string? StackTrace { get; set; }
    }
}