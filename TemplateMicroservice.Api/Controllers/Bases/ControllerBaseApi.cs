using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IResult = TemplateMicroservice.Application.Response.Contracts.IResult;

namespace TemplateMicroservice.Api.Controllers.Bases;

[ApiController]
public abstract class ControllerBaseApi : ControllerBase
{
    internal IActionResult Return(IResult result)
    {
        return StatusCode((int)result.StatusCode, result);
    }

    internal Guid GetIdUser()
    {
        return Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
    }
}