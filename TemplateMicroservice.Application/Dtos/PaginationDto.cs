namespace TemplateMicroservice.Application.Dtos
{
    public record PaginationDto<T>(int Total, int Page, int Limit, IEnumerable<T> Data);

}

