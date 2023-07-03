using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Commands.DeleteCar;
public record DeleteCarCommand(Guid Id) : IRequest<ResponseResult>;
