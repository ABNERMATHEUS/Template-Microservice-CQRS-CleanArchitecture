using FluentValidation;
using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Queries.QueryCar;

public class GetByIdQueryCar : IRequest<ResponseResult>
{
    public Guid Id { get; set; }
}

public class GetByIdQueryCarValidation : AbstractValidator<GetByIdQueryCar>
{
    public GetByIdQueryCarValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();
    }
}