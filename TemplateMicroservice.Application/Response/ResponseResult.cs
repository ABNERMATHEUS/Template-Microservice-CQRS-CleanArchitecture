using System.Net;
using TemplateMicroservice.Application.Response.Contracts;

namespace TemplateMicroservice.Application.Response;

public class ResponseResult : IResult
{
    public ResponseResult(bool success, string? message, HttpStatusCode statusCode, object? data = null)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Data = data;
    }

    public ResponseResult(bool success, HttpStatusCode statusCode, object? data)
    {
        Success = success;
        StatusCode = statusCode;
        Data = data;
    }

    public bool Success { get; }
    public string? Message { get; }
    public HttpStatusCode StatusCode { get;  }
    public object? Data { get; }
}