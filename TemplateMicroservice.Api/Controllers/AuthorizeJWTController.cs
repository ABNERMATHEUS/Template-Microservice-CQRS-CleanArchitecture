using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TemplateMicroservice.Api.Controllers.Bases;
using TemplateMicroservice.Core.Services;

namespace TemplateMicroservice.Api.Controllers;

[Route("v1/[controller]")]
public class AuthorizeJWTController : ControllerBaseApi
{
    #region GET

    [HttpGet("Authenticated")]
    [Authorize]
    public IActionResult VerifyAuthenticated()
    {
        return Ok($"Authenticated. user id: {GetIdUser()}");
    }

    [AllowAnonymous]
    [HttpGet("GetToken")]
    public IActionResult GetToken([FromServices] ITokenService tokenService)
    {
        return Ok(new { token = tokenService.GenerateAccessTokenAsync(Guid.NewGuid(), "admin") });
    }

    #endregion
}