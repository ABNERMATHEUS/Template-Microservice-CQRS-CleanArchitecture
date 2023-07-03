using MediatR;
using TemplateMicroservice.Application.Response;
using TemplateMicroservice.Domain.Entities;
using TemplateMicroservice.Domain.Repositories.Contracts;

namespace TemplateMicroservice.Application.Commands.DeleteCar;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, ResponseResult>
{
    private readonly IRepository<Car> _repositoryCar;
    public DeleteCarCommandHandler(IRepository<Car> repositoryCar)
    {
        _repositoryCar = repositoryCar;
    }

    public async Task<ResponseResult> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var car = await _repositoryCar.GetByIdAsync(request.Id, cancellationToken);
            if (car is null)
            {
                return ResponseResult.ReturnFail(message: "Dont found");
            }

            _repositoryCar.Delete(car);
            await _repositoryCar.SaveAsync(cancellationToken);
            return ResponseResult.ReturnSuccess("Deleted successfully");

        }
        catch (Exception ex)
        {
            return ResponseResult.ReturnError(ex.Message, ex);
        }
    }
}
