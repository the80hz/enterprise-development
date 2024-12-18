using AutoMapper;
using Staff.Domain.Models;
using Staff.WebAPI.Dto;

namespace Staff.WebAPI;

/// <summary>
/// Класс для настройки маппинга между моделями и DTO.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Конструктор класса.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Workshop, WorkshopDto>().ReverseMap();
        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<EmploymentArchiveRecord, EmploymentArchiveRecordDto>().ReverseMap();
        CreateMap<UnionBenefit, UnionBenefitDto>().ReverseMap();
    }
}