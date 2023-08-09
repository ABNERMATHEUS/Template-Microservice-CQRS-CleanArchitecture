using FluentValidation;

namespace TemplateMicroservice.Application.Commands.CreateCar
{
    public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(x => x.Color).NotNull();
            RuleFor(x => x.Model).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Year).NotNull();
        }
    }
}
