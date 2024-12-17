using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Department.
/// Реализует интерфейс IRepository для управления отделами.
/// </summary>
public class DepartmentRepository : IRepository<Department>
{
    private readonly List<Department> _departments = new();

    public IEnumerable<Department> GetAll() => _departments;

    public Department? GetById(int id) => _departments.Find(d => d.DepartmentId == id);

    public Department? Post(Department entity)
    {
        _departments.Add(entity);
        return entity;
    }

    public bool Put(Department entity)
    {
        var existingDepartment = GetById(entity.DepartmentId);
        if (existingDepartment == null)
            return false;

        existingDepartment.Name = entity.Name;
        return true;
    }

    public bool Delete(int id)
    {
        var department = GetById(id);
        if (department == null)
            return false;

        _departments.Remove(department);
        return true;
    }
}
