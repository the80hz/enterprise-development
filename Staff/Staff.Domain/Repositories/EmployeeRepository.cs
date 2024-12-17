using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Employee.
/// Реализует интерфейс IRepository для управления сотрудниками.
/// </summary>
public class EmployeeRepository : IRepository<Employee>
{
    private readonly List<Employee> _employees = new();

    public IEnumerable<Employee> GetAll() => _employees;

    public Employee? GetById(int id) => _employees.Find(e => e.RegistrationNumber == id);

    public Employee? Post(Employee entity)
    {
        _employees.Add(entity);
        return entity;
    }

    public bool Put(Employee entity)
    {
        var existingEmployee = GetById(entity.RegistrationNumber);
        if (existingEmployee == null)
            return false;

        existingEmployee.Surname = entity.Surname;
        existingEmployee.Name = entity.Name;
        existingEmployee.Patronymic = entity.Patronymic;
        existingEmployee.DateOfBirth = entity.DateOfBirth;
        existingEmployee.Gender = entity.Gender;
        existingEmployee.DateOfHire = entity.DateOfHire;
        existingEmployee.Departments = entity.Departments;
        existingEmployee.Workshop = entity.Workshop;
        existingEmployee.Position = entity.Position;
        existingEmployee.Address = entity.Address;
        existingEmployee.WorkPhone = entity.WorkPhone;
        existingEmployee.HomePhone = entity.HomePhone;
        existingEmployee.MaritalStatus = entity.MaritalStatus;
        existingEmployee.FamilySize = entity.FamilySize;
        existingEmployee.NumberOfChildren = entity.NumberOfChildren;
        existingEmployee.EmploymentArchive = entity.EmploymentArchive;
        existingEmployee.IsUnionMember = entity.IsUnionMember;
        existingEmployee.UnionBenefits = entity.UnionBenefits;
        return true;
    }

    public bool Delete(int id)
    {
        var employee = GetById(id);
        if (employee == null)
            return false;

        _employees.Remove(employee);
        return true;
    }
}
