namespace Staff.Domain;

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
    public string Name { get; set; }
}
