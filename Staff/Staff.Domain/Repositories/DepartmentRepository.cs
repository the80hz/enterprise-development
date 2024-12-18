using Staff.Domain.Models;

namespace Staff.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Department.
/// Реализует интерфейс IRepository для управления отделами.
/// </summary>
public class DepartmentRepository : IRepository<Department>
{
    private readonly List<Department> _departments = new();

    /// <summary>
    /// Получает все отделы.
    /// </summary>
    public IEnumerable<Department> GetAll() => _departments;

    /// <summary>
    /// Получает отдел по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела.</param>
    public Department? GetById(int id) => _departments.Find(d => d.DepartmentId == id);

    /// <summary>
    /// Добавляет новый отдел.
    /// </summary>
    /// <param name="entity">Новый отдел для добавления.</param>
    public Department? Post(Department entity)
    {
        _departments.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет данные отдела.
    /// </summary>
    /// <param name="entity">Обновленные данные отдела.</param>
    public bool Put(Department entity)
    {
        var existingDepartment = GetById(entity.DepartmentId);
        if (existingDepartment == null)
            return false;

        existingDepartment.Name = entity.Name;
        return true;
    }

    /// <summary>
    /// Удаляет отдел по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор отдела для удаления.</param>
    public bool Delete(int id)
    {
        var department = GetById(id);
        if (department == null)
            return false;

        _departments.Remove(department);
        return true;
    }
}
