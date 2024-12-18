namespace Staff.WebAPI.Dto;

/// <summary>
/// DTO для передачи данных о цехе.
/// </summary>
public class WorkshopDto
{
    /// <summary>
    /// Идентификатор цеха.
    /// </summary>
    public int WorkshopId { get; set; }

    /// <summary>
    /// Название цеха.
    /// </summary>
    public required string Name { get; set; }
}