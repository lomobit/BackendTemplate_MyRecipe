using Microsoft.AspNetCore.Mvc;
using MyRecipe.Contracts.Api;

namespace MyRecipe.Api.Controllers.v1
{
    public abstract class BaseApiController : Controller
    {
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
        /// <returns>Результат вызова API.</returns>
        protected IActionResult Error(IReadOnlyCollection<string> errors)
        {
            return Ok(ApiResult<IReadOnlyCollection<string>>.ErrorResult(errors));
        }
    }
}
