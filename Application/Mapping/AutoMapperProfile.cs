using AutoMapper;
using FacilityManagementSystem.Domain.Entities;
using FacilityManagementSystem.Application.DTOs.AreaDto;
using FacilityManagementSystem.Application.DTOs.RequestDto;
using FacilityManagementSystem.Application.DTOs.AssetDto;
using FacilityManagementSystem.Application.DTOs.WorkOrderDto;
using FacilityManagementSystem.Application.DTOs.UserDto;
using FacilityManagementSystem.Application.DTOs.FacilityDto;
using FacilityManagementSystem.Domain.Enums;


namespace FacilityManagementSystem.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //user mappings
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

            //area mappings
            CreateMap<Area, AreaReadDto>();
            CreateMap<AreaCreateDto, Area>();
            CreateMap<AreaUpdateDto, Area>();
            //work order mappings
            CreateMap<WorkOrder, WorkOrderReadDto>()
                .ForMember(dest => dest.TechnicianName, opt => opt.MapFrom(src => src.Technician))
;
            CreateMap<WorkOrderCreateDto, WorkOrder>()
                .ForMember(dest => dest.Technician, opt => opt.MapFrom(src => src.TechnicianName))
;
            CreateMap<WorkOrderUpdateDto, WorkOrder>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
            //asset mappings
            CreateMap<Asset, AssetReadDto>();
            CreateMap<AssetCreateDto, Asset>();
            // CreateMap<AssetUpdateDto, Asset>();
            CreateMap<AssetUpdateDto, Asset>()
                 .ForAllMembers(opt =>
                     opt.Condition((src, dest, srcMember) => srcMember != null));

            //maintenance request mappings
            CreateMap<MaintenanceRequest,RequestReadDto>();
            CreateMap<RequestCreateDto, MaintenanceRequest>();
            CreateMap<RequestUpdateDto, MaintenanceRequest>()
             .ForAllMembers(opt =>
                 opt.Condition((src, dest, srcMember) => srcMember != null));


            // Facility mappings
            CreateMap<Facility, FacilityReadDto>();
            CreateMap<FacilityCreateDto, Facility>();

            CreateMap<FacilityUpdateDto, Facility>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

            //

            CreateMap<Asset, AssetReadDto>()
            .ForMember(dest => dest.Status,
               opt => opt.MapFrom(src => src.Status.ToString()));







        }
    }
}
