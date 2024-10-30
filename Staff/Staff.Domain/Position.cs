namespace Staff.Domain;

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
    public string Title { get; set; }
}
