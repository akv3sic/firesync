using AutoMapper;
using FireSync.DTOs.Interventions;
using FireSync.Entities;

namespace FireSync.MappingProfiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Intervention, InterventionOutputDto>().ReverseMap();
        }
    }
}
