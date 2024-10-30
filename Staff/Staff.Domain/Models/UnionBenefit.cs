using Staff.Domain.Enums;

namespace Staff.Domain.Models;

/// <summary>
/// Представляет льготную профсоюзную путевку, полученную сотрудником.
/// </summary>
public class UnionBenefit
{
    /// <summary>
    /// Идентификатор льготной путевки.
    /// </summary>
    public int UnionBenefitId { get; set; }

    /// <summary>
    /// Тип льготной путевки.
    /// </summary>
    public BenefitType BenefitType { get; set; }

    /// <summary>
    /// Дата получения льготной путевки.
    /// </summary>
    public DateTime DateReceived { get; set; }
}
