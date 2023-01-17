using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Enums;
using TemplateMicroservice.Domain.Repositories;

namespace TemplateMicroservice.Application.Commands.CreateCar;

public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, ResponseResult>
{
    private readonly ILogger<CreateCarCommandHandler> _logger;
    private readonly ICarRepository _carRepository;

    public CreateCarCommandHandler(ILogger<CreateCarCommandHandler> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }


    public async Task<ResponseResult> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateCarCommandValidator();
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);

            if (!resultValidator.IsValid)
            {
                return ResponseResult.ReturnFail(resultValidator.Errors);
            }

            var car = new Car(Guid.NewGuid(), "Abner", request.Name, request.Color, request.Model,
                EEntityStatus.ACTIVE);

            await _carRepository.CreateAsync(car, cancellationToken);
            await _carRepository.SaveAsync(cancellationToken);

            _logger.LogInformation($"Successfully created. Process {nameof(CreateCarCommandHandler)}",
                request);
            return ResponseResult.ReturnSuccess(car.Id, "Successfully created.", HttpStatusCode.Created);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error when process: {nameof(CreateCarCommandHandler)}", request);
            return ResponseResult.ReturnError(ex.Message);
        }
    }
}