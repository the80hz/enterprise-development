namespace Staff.Domain.Models;

/// <summary>
/// Представляет цех предприятия.
/// </summary>
public class Workshop
{
    /// <summary>
    /// Идентификатор цеха.
    /// </summary>
    public int WorkshopId { get; set; }

    /// <summary>
    /// Название цеха.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Отделы, входящие в цех.
    /// </summary>
    public List<Employee> Employees { get; set; } = [];
}
