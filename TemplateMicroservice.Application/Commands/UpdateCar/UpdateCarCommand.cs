using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Commands.UpdateCar;

public record UpdateCarCommand(Guid Id, string Name, string Color, string Model, int Year) : IRequest<ResponseResult>;
