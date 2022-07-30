using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Application.Queries.QueryCar;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Core.Repositories;

namespace TemplateMicroservice.Application.Handlers.HandlerCar;

public class GetByIdQueryCarHandler :  IRequestHandler<GetByIdQueryCar, ResponseResult>
{
    private readonly ILogger<GetByIdQueryCarHandler> _logger;
    private readonly ICarRepository _carRepository;

    public GetByIdQueryCarHandler(ILogger<GetByIdQueryCarHandler> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }

    public  async Task<ResponseResult> Handle(GetByIdQueryCar request, CancellationToken cancellationToken)
    {
        try
        {

            var validator = new GetByIdQueryCarValidation();
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            var result = _carRepository.Get().FirstOrDefault(x => x.Id == request.Id);
            return new ResponseResult(true, null, HttpStatusCode.OK, result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when process: {nameof(GetByIdQueryCarHandler)}");
            return new ResponseResult(false, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}