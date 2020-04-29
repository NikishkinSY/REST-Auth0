using AutoMapper;

namespace DBA.Application
{
    public class AppServicesProfile : Profile
    {
        public AppServicesProfile()
        {
            CreateMap<Infrastructure.Entities.CTeleport.Airport, Domain.Entities.Airport>()
                .ForMember(d => d.Latitude, m => m.MapFrom(d => d.Location.Latitude))
                .ForMember(d => d.Longitude, m => m.MapFrom(d => d.Location.Longitude));
        }
    }
}
