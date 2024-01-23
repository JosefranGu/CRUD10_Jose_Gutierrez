using AutoMapper;
using JourneyMicroservice.Core;

namespace JourneyMicroservice.ApplicationServices
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Journey, Journey>().ReverseMap();
        }
    }
}
