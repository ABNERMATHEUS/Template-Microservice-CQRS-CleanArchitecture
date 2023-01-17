using MediatR;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Domain.Repositories;

namespace TemplateMicroservice.Application.Queries.GetByIdCar;

public sealed class GetByIdQueryCarHandler : IRequestHandler<GetByIdQueryCar, ResponseResult>
{
    private readonly ILogger<GetByIdQueryCarHandler> _logger;
    private readonly ICarRepository _carRepository;

    public GetByIdQueryCarHandler(ILogger<GetByIdQueryCarHandler> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }

    public async Task<ResponseResult> Handle(GetByIdQueryCar request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new GetByIdQueryCarValidator();
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            var result = _carRepository.GetByIdAsync(request.Id);
            return ResponseResult.ReturnSuccess(result);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when process: {nameof(GetByIdQueryCarHandler)}");
            return ResponseResult.ReturnError(ex.Message);
        }
    }
}