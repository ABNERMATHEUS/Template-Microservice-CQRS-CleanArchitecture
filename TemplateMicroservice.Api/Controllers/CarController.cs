using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Api.Controllers.Bases;
using TemplateMicroservice.Application.Commands.CreateCar;
using TemplateMicroservice.Application.Queries.GetByIdCar;

namespace TemplateMicroservice.Api.Controllers;

[Route("v1/[controller]")]
public sealed class CarController : ControllerBaseApi
{
    #region POST

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateCarCommand request,
        [FromServices] IMediator mediator
    )
    {
        var result = await mediator.Send(request);
        return base.Return(result);
    }

    #endregion

    #region GET

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetByIdQueryCar request,
        [FromServices] IMediator mediator
    )
    {
        var result = await mediator.Send(request);
        return base.Return(result);
    }

    #endregion
}