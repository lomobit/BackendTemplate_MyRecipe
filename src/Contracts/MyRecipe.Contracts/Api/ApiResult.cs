
using MyRecipe.Contracts.Enums.Api;

namespace MyRecipe.Contracts.Api
{
    /// <summary>
    /// Результат выполнения методов Api.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// Данные
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Признак: выполнено успешно
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Коллекция с информацией
        /// </summary>
        public List<ApiResultMessage> Messages { get; set; }

        /// <summary>
        /// Конструктор <see cref="ApiResult{T}"/>
        /// </summary>
        public ApiResult()
        {
            Messages = new List<ApiResultMessage>();
        }

        /// <summary>
        /// Успешное выполнение операции.
        /// </summary>
        /// <returns>Результат выполнения метода.</returns>
        public static ApiResult<T> SuccessResult()
        {
            return new ApiResult<T>()
            {
                Success = true
            };
        }

        /// <summary>
        /// Успешное выполнение операции.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Результат выполнения метода.</returns>
        public static ApiResult<T> SuccessResult(T? data)
        {
            return new ApiResult<T>()
            {
                Data = data,
                Success = true
            };
        }

        /// <summary>
        /// Успешное выполнение операции.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="message">Сообщение.</param>
        /// <returns>Результат выполнения метода.</returns>
        public static ApiResult<T> ErrorResult(T data, string? message = null)
        {
            var apiResult = new ApiResult<T>()
            {
                Data = data,
                Success = false,
            };

            if (!string.IsNullOrEmpty(message))
            {
                apiResult.Messages.Add(new ApiResultMessage()
                {
                    Value = message,
                    Type = ApiResultMessageType.Error,
                    Key = "Error"
                });
            }

            return apiResult;
        }
    }
}
