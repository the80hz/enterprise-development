namespace Staff.WebAPI.Dto;

using Staff.Domain.Enums;

/// <summary>
/// DTO для передачи данных о профсоюзной льготе.
/// </summary>
public class UnionBenefitDto
{
    /// <summary>
    /// Идентификатор льготы.
    /// </summary>
    public int UnionBenefitId { get; set; }

    /// <summary>
    /// Тип льготы.
    /// </summary>
    public BenefitType BenefitType { get; set; }

    /// <summary>
    /// Дата получения льготы.
    /// </summary>
    public DateTime DateReceived { get; set; }
}