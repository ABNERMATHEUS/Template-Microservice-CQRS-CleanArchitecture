using MediatR;
using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Api.Controllers.Bases;
using TemplateMicroservice.Application.Commands.CommandCar;
using TemplateMicroservice.Application.Queries.QueryCar;

namespace TemplateMicroservice.Api.Controllers;

[Route("[controller]")]
public class CarController : ControllerBaseApi
{


    #region POST

    [HttpPost]
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