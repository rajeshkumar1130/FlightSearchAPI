using AutoMapper;
using FlightSearch.API.Data.Dto.Flight;
using FlightSearch.API.Data.Models;

namespace FlightSearch.API.Core.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, ResponseDto>();
        }
    }
}
