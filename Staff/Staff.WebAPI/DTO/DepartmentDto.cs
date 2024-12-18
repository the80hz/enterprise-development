namespace Staff.WebAPI.Dto;

/// <summary>
/// DTO для передачи данных об отделе.
/// </summary>
public class DepartmentDto
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