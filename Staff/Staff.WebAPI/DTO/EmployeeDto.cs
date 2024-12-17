namespace Staff.WebAPI.Dto;

using Staff.Domain.Enums;

public class EmployeeDto
{
    public int RegistrationNumber { get; set; }
    public required string Surname { get; set; }
    public required string Name { get; set; }
    public required string Patronymic { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfHire { get; set; }
    public List<DepartmentDto> Departments { get; set; } = [];
    public required WorkshopDto Workshop { get; set; }
    public required PositionDto Position { get; set; }
    public required AddressDto Address { get; set; }
    public required string WorkPhone { get; set; }
    public required string HomePhone { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int FamilySize { get; set; }
    public int NumberOfChildren { get; set; }
    public List<EmploymentArchiveRecordDto> EmploymentArchive { get; set; } = [];
    public bool IsUnionMember { get; set; }
    public List<UnionBenefitDto> UnionBenefits { get; set; } = [];
}