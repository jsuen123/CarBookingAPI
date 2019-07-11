using AutoMapper;
using CarBookingAPI.Entities;
using CarBookingAPI.Models;

namespace CarBookingAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<BookingForCreationDto, Booking>();
            CreateMap<BookingDto, Booking>().ReverseMap();
        }
    }
}
