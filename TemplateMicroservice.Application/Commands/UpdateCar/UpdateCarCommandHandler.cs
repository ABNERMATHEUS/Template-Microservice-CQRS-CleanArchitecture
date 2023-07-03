using MediatR;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Repositories.Contracts;

namespace TemplateMicroservice.Application.Commands.UpdateCar;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, ResponseResult>
{
    private readonly IRepository<Car> _repositoryCar;

    public UpdateCarCommandHandler(IRepository<Car> repositoryCar)
    {
        _repositoryCar = repositoryCar;
    }

    public async Task<ResponseResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var car = await _repositoryCar.GetByIdAsync(request.Id, cancellationToken);
            if (car is null)
            {
                return ResponseResult.ReturnFail(message: "Dont found.");
            }

            car.Update(request.Color, request.Model, request.Name);

            _repositoryCar.Update(car);
            await _repositoryCar.SaveAsync(cancellationToken);
            return ResponseResult.ReturnSuccess("Updated successfully");
        }catch(Exception ex)
        {
            return ResponseResult.ReturnError(message: ex.ToString());
        }
    }
}
