using Microsoft.AspNetCore.Mvc;
using MyRecipe.Contracts.Api;
using System.ComponentModel.DataAnnotations;

namespace MyRecipe.Api.Controllers.v1
{
    public abstract class BaseApiController : Controller
    {
        protected virtual async Task<IActionResult> CallApiActionWithResultAsync<T>(Func<Task<T>> apiAction)
        {
            try
            {
                var result = await apiAction.Invoke();
                return Success(result);
            }
            catch (Exception ex) 
            {
                return Error(new Dictionary<string, string> { { ex.GetType().Name, ex.Message } });
            }
        }

        /// <summary>
        /// Успешное завершение вызова.
        /// </summary>
        /// <typeparam name="T">Тип возвращаемых данных.</typeparam>
        /// <param name="data">Данные.</param>
        /// <returns>Результат вызова API.</returns>
        protected IActionResult Success<T>(T? data)
        {
            return Ok(ApiResult<T>.SuccessResult(data));
        }

        /// <summary>
        /// Успешное завершение вызова.
        /// </summary>
        /// <returns>Результат вызова API.</returns>
        protected IActionResult Success()
        {
            return Ok(ApiResult<string>.SuccessResult(null));
        }

        /// <summary>
        /// Завершение вызова с ошибкой.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="errors">Ошибки.</param>
        /// <returns>Результат вызова API.</returns>
        protected IActionResult Error<T>(T? data, IDictionary<string, string> errors)
        {
            return Ok(ApiResult<T>.ErrorResult(data, errors));
        }

        /// <summary>
        /// Завершение вызова с ошибкой.
        /// </summary>
        /// <param name="errors">Ошибки.</param>
        /// <returns>Результат вызова API.</returns>
        protected IActionResult Error(IDictionary<string, string> errors)
        {
            return Ok(ApiResult<string>.ErrorResult(null, errors));
        }
    }
}
