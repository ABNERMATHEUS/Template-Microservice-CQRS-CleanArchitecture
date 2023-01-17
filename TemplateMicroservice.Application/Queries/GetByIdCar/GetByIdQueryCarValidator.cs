using FluentValidation;

namespace TemplateMicroservice.Application.Queries.GetByIdCar
{
    public sealed class GetByIdQueryCarValidator : AbstractValidator<GetByIdQueryCar>
    {
        public GetByIdQueryCarValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
