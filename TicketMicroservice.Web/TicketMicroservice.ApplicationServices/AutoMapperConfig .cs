using AutoMapper;
using TicketMicroservice.Core;

namespace TicketMicroservice.ApplicationServices
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Ticket, Ticket>().ReverseMap();
        }
    }
}
