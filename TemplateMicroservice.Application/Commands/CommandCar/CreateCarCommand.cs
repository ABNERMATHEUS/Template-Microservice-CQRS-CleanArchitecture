using FluentValidation;
using MediatR;
using TemplateMicroservice.Application.Response;

namespace TemplateMicroservice.Application.Commands.CommandCar;

public class CreateCarCommand : IRequest<ResponseResult>
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }
}

public class CreateCarCommandValidation : AbstractValidator<CreateCarCommand> {
    public CreateCarCommandValidation()
    {
        RuleFor(x => x.Color).NotNull();
        RuleFor(x => x.Model).NotNull();
        RuleFor(x => x.Name).NotNull();
    }
}