namespace Staff.Domain.Models;

/// <summary>
/// Представляет запись в архиве трудовой деятельности сотрудника.
/// </summary>
public class EmploymentArchiveRecord
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public int RecordId { get; set; }

    /// <summary>
    /// Дата начала работы на должности.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания работы на должности. Null, если сотрудник в настоящее время работает.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Должность, на которой работал сотрудник.
    /// </summary>
    public required Position Position { get; set; }

    /// <summary>
    /// Сотрудник, работавший на должности.
    /// </summary>
    public Employee? Employee { get; set; }
}
