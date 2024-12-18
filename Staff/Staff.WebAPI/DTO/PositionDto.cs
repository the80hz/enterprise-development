namespace Staff.WebAPI.Dto;

/// <summary>
/// DTO для передачи данных о должности.
/// </summary>
public class PositionDto
{
    /// <summary>
    /// Идентификатор должности.
    /// </summary>
    public int PositionId { get; set; }

    /// <summary>
    /// Название должности.
    /// </summary>
    public required string Title { get; set; }
}