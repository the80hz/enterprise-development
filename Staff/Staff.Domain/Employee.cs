namespace Staff.Domain;

public class Employee
{
    public int RegistrationNumber { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfHire { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();
    public Workshop Workshop { get; set; }
    public Position Position { get; set; }
    public Address Address { get; set; }
    public string WorkPhone { get; set; }
    public string HomePhone { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int FamilySize { get; set; }
    public int NumberOfChildren { get; set; }
    public List<EmploymentArchiveRecord> EmploymentArchive { get; set; } = new List<EmploymentArchiveRecord>();
    public bool IsUnionMember { get; set; }
    public List<UnionBenefit> UnionBenefits { get; set; } = new List<UnionBenefit>();
}