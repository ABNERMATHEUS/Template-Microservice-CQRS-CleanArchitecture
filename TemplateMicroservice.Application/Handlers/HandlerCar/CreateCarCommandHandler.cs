using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using TemplateMicroservice.Application.Commands.CommandCar;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Core.Entities;
using TemplateMicroservice.Core.Enums;
using TemplateMicroservice.Core.Repositories;

namespace TemplateMicroservice.Application.Handlers.HandlerCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, ResponseResult>
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
            var validator = new CreateCarCommandValidation();
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