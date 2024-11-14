using Staff.Domain.Enums;

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
}
