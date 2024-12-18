namespace Staff.WebAPI.Dto;

/// <summary>
/// DTO для передачи данных об архивной записи о трудоустройстве.
/// </summary>
public class EmploymentArchiveRecordDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public int RecordId { get; set; }

    /// <summary>
    /// Дата начала работы.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Дата окончания работы.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Должность сотрудника.
    /// </summary>
    public required PositionDto Position { get; set; }
}