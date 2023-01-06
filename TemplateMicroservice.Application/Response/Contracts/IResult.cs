using System.Net;

namespace TemplateMicroservice.Application.Response.Contracts;

public interface IResult
{
    public bool Success { get;}
    public string? Message { get; }
    
    public HttpStatusCode StatusCode { get;  }
    public object Data { get;  }
}