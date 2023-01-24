using MyRecipe.Contracts.Enums.Api;

namespace MyRecipe.Contracts.Api
{
    /// <summary>
    /// Сообщение для SaveResult
    /// </summary>
    public class ApiResultMessage
    {
        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public ApiResultMessageType Type { get; set; }

        /// <summary>
        /// Значение сообщения
        /// </summary>
        public string Value { get; set; }
    }
}
