using AutoMapper;
using FireSync.DTOs.Interventions;
using FireSync.DTOs.InterventionTypes;
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
            CreateMap<Intervention, InterventionOutputDto>()
                .ForMember(dest => dest.InterventionTypeName, opt => opt.MapFrom(src =>
                    src.InterventionType != null ? src.InterventionType.Name : string.Empty))
                .ReverseMap();
            CreateMap<InterventionInputDto, Intervention>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.HasValue ? DateTime.SpecifyKind(src.StartTime.Value, DateTimeKind.Utc) : (DateTime?)null))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.HasValue ? DateTime.SpecifyKind(src.EndTime.Value, DateTimeKind.Utc) : (DateTime?)null));
            CreateMap<InterventionType, InterventionTypeOutputDto>();
            CreateMap<InterventionTypeInputDto, InterventionType>();
            CreateMap<InterventionTypeUpdateDto, InterventionType>();
            CreateMap<Vehicle, VehicleOutputDto>();
            CreateMap<VehicleInputDto, Vehicle>();
            CreateMap<UserInputDto, ApplicationUser>();
        }
    }
}
