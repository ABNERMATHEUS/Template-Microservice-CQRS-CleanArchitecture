using System;
namespace TemplateMicroservice.Application.Dtos
{
    public sealed class PaginationDto<T> 
    {
        public PaginationDto(int total, int page, int limit, IEnumerable<T> data)
        {
            Total = total;
            Page = page;
            Limit = limit;
            Data = data;
        }

        public int Total { get; private set; }
        public int Page { get; private set; } = 0;
        public int Limit { get; private set; }
        public IEnumerable<T> Data { get; private set; }
    }
}

