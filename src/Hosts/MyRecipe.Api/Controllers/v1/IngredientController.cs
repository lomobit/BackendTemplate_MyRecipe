using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRecipe.Contracts.Api;
using MyRecipe.Contracts.Ingredient;
using MyRecipe.Handlers.Ingredient;

namespace MyRecipe.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ApiResult<ApiError>), statusCode: 400)]
    [ProducesResponseType(typeof(ApiResult<ApiError>), statusCode: 500)]
    public class IngredientController : BaseApiController
    {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(ApiResult<IngredientDto>), statusCode: 200)]
        public async Task<IActionResult> Add([FromBody] IngredientAddCommand command, CancellationToken cancellationToken)
        {
            var data = await _mediator.Send(command, cancellationToken);
            return Success(data);
        }
    }
}
