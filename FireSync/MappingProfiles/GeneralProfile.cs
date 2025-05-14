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
            CreateMap<ApplicationUser, UserBriefOutputDto>()
                .ForMember(d => d.FullName,
                           opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}".Trim()));

            CreateMap<Intervention, InterventionDetailsOutputDto>()
                .ForMember(d => d.InterventionTypeName,
                           opt => opt.MapFrom(s => s.InterventionType != null ? s.InterventionType.Name : string.Empty))
                .ForMember(d => d.Firefighters,
                           opt => opt.MapFrom(s => s.ApplicationUserInterventions
                                                      .Select(aui => aui.ApplicationUser)));

        }
    }
}
