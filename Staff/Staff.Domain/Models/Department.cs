namespace Staff.Domain.Models;

/// <summary>
/// Представляет отдел предприятия.
/// </summary>
public class Department
{
    /// <summary>
    /// Идентификатор отдела.
    /// </summary>
    public int DepartmentId { get; set; }

    /// <summary>
    /// Название отдела.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Сотрудники, числящиеся в отделе.
    /// </summary>
    public List<Employee> Employees { get; set; } = new();
}
