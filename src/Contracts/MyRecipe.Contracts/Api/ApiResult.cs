
using MyRecipe.Contracts.Enums.Api;
using System.Collections;

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
        /// <param name="messages">Сообщения.</param>
        /// <returns>Результат выполнения метода.</returns>
        public static ApiResult<T> ErrorResult(T? data, IDictionary? messages)
        {
            var apiResult = new ApiResult<T>()
            {
                Data = data,
                Success = false,
            };

            var stringMessages = messages as IDictionary<string, string>;
            if (stringMessages == null)
            {
                return apiResult;
            }

            foreach (var message in stringMessages)
            {
                apiResult.Messages.Add(new ApiResultMessage()
                {
                    Value = message.Key,
                    Type = ApiResultMessageType.Error,
                    Key = message.Value,
                });
            }

            return apiResult;
        }
    }
}
