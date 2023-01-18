using TemplateMicroservice.Domain.Enums;

namespace TemplateMicroservice.Application.Dtos
{
    public record CarDto(string Name, string Color, string Model, EEntityStatus Status);

}
