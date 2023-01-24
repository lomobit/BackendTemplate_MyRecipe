using Microsoft.AspNetCore.Mvc;
using MyRecipe.Contracts.Api;
using MyRecipe.Contracts.Ingredient;

namespace MyRecipe.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResult<ApiError>), statusCode: 400)]
    [ProducesResponseType(typeof(ApiResult<ApiError>), statusCode: 500)]
    public class IngredientController : BaseApiController
    {
        public IngredientController()
        {
            
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(ApiResult<IngredientDto>), statusCode: 200)]
        public IActionResult Add([FromBody] IngredientAddCommand command, CancellationToken cancellationToken)
        {
            var data = new IngredientDto()
            {
                Id = new Random().Next(),
                Name = command.Name,
                Description = command.Description,
            };
            return Success(data);
        }
    }
}
