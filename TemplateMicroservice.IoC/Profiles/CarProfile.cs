using AutoMapper;
using TemplateMicroservice.Application.Dtos;
using TemplateMicroservice.Domain.Entities;

namespace TemplateMicroservice.IoC.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();                
        }
    }
}
