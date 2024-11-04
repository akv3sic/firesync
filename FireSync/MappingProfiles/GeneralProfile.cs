using AutoMapper;
using FireSync.DTOs.Interventions;
using FireSync.DTOs.Vehicles;
using FireSync.Entities;

namespace FireSync.MappingProfiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Intervention, InterventionOutputDto>().ReverseMap();
            CreateMap<Vehicle, VehicleOutputDto>();
        }
    }
}
