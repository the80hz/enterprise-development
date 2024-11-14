using Staff.Domain.Enums;

namespace Staff.Domain.Models;

/// <summary>
/// Представляет сотрудника предприятия.
/// </summary>
public class Employee
{
    public int RegistrationNumber { get; set; }
    public required string Surname { get; set; }
    public required string Name { get; set; }
    public required string Patronymic { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfHire { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();
    public required Workshop Workshop { get; set; }
    public required Position Position { get; set; }
    public required Address Address { get; set; }
    public required string WorkPhone { get; set; }
    public required string HomePhone { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int FamilySize { get; set; }
    public int NumberOfChildren { get; set; }
    public List<EmploymentArchiveRecord> EmploymentArchive { get; set; } = new List<EmploymentArchiveRecord>();
    public bool IsUnionMember { get; set; }
    public List<UnionBenefit> UnionBenefits { get; set; } = new List<UnionBenefit>();
}
