using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Queries.GetByIdCar;

public record GetByIdQueryCar(Guid Id) : IRequest<ResponseResult>;
