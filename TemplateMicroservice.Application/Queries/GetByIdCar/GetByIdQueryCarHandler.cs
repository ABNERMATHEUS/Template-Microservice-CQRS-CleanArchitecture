using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Application.Dtos;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Domain.Repositories;

namespace TemplateMicroservice.Application.Queries.GetByIdCar;

public sealed class GetByIdQueryCarHandler : IRequestHandler<GetByIdQueryCar, ResponseResult>
{
    private readonly ILogger<GetByIdQueryCarHandler> _logger;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetByIdQueryCarHandler(ILogger<GetByIdQueryCarHandler> logger, ICarRepository carRepository, IMapper mapper)
    {
        _logger = logger;
        _carRepository = carRepository;
        _mapper=mapper;
    }

    public async Task<ResponseResult> Handle(GetByIdQueryCar request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new GetByIdQueryCarValidator();
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            var result = await _carRepository.GetByIdAsync(request.Id);
            var carDto = _mapper.Map<CarDto>(result);
            return ResponseResult.ReturnSuccess(carDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when process: {nameof(GetByIdQueryCarHandler)}");
            return ResponseResult.ReturnError(ex.Message);
        }
    }
}