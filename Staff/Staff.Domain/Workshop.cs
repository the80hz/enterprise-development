namespace Staff.Domain;

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
    public string Name { get; set; }
}
