using System.Net;
using TemplateMicroservice.Application.Response.Contracts;

namespace TemplateMicroservice.Application.Response;

public sealed class ResponseResult : IResult
{
    private ResponseResult(bool success, string? message, HttpStatusCode statusCode, object? data = null)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public static ResponseResult ReturnFail(object? data = null, string? message = null)
    {
        return new ResponseResult(false, message, HttpStatusCode.BadRequest, data);
    }

    public static ResponseResult ReturnError(string? message = null, object? data = null)
    {
        return new ResponseResult(false, message, HttpStatusCode.InternalServerError, data);
    }

    public static ResponseResult ReturnSuccess(object? data = null, string? message = null,
        HttpStatusCode httpStatusCode = HttpStatusCode.OK)
    {
        return new ResponseResult(true, message, httpStatusCode, data);
    }

    public bool Success { get; }
    public string? Message { get; }
    public HttpStatusCode StatusCode { get; }
    public object? Data { get; }
}