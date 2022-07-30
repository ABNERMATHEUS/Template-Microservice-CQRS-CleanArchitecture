using Microsoft.AspNetCore.Mvc;
using IResult = TemplateMicroservice.Application.Response.Contracts.IResult;

namespace TemplateMicroservice.Api.Controllers.Bases;


[ApiController]
public abstract class ControllerBaseApi : ControllerBase
{
    internal IActionResult Return(IResult result)
    {
        return StatusCode((int) result.StatusCode, result);
    }
}