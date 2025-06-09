using AutoMapper;

namespace Application.Mappings;

public class VehicleMappingProfile : Profile
{
    public VehicleMappingProfile()
    {
        CreateMap<Vehicle, VehicleDto>()
            .ForMember(dest => dest.ChassisSeries, opt => opt.MapFrom(src => src.Chassis.ChassisSeries))
            .ForMember(dest => dest.ChassisNumber, opt => opt.MapFrom(src => src.Chassis.ChassisNumber))
            .ForMember(dest => dest.ChassisId, opt => opt.MapFrom(src => src.Chassis.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color));

        CreateMap<VehicleDtoCreate, Vehicle>()
            .ConstructUsing(dto => new Vehicle(
                new Chassis { ChassisSeries = dto.ChassisSeries, ChassisNumber = dto.ChassisNumber },
                dto.Type,
                dto.Color
            ));
    }
}
