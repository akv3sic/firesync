using AutoMapper;
using FireSync.DTOs.Interventions;
using FireSync.DTOs.Users;
using FireSync.DTOs.Vehicles;
using FireSync.Entities;
using FireSync.Models;

namespace FireSync.MappingProfiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Intervention, InterventionOutputDto>().ReverseMap();
            CreateMap<Vehicle, VehicleOutputDto>();
            CreateMap<UserInputDto, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
