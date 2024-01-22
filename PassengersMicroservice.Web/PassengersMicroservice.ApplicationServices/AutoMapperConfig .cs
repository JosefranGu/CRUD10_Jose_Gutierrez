using AutoMapper;
using PassengersMicroservice.Core;

namespace Passengers.ApplicationServices
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Passenger, Passenger>().ReverseMap();
        }
    }
}
