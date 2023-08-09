using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Commands.CreateCar;

public record CreateCarCommand(string Name, string Color, string Model, int Year) : IRequest<ResponseResult>;
