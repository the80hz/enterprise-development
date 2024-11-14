namespace Staff.Domain.Models;

/// <summary>
/// Представляет должность на предприятии.
/// </summary>
public class Position
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
