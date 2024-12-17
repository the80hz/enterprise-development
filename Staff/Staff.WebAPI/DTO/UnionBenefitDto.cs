namespace Staff.WebAPI.Dto;

using Staff.Domain.Enums;

public class UnionBenefitDto
{
    public int UnionBenefitId { get; set; }
    public BenefitType BenefitType { get; set; }
    public DateTime DateReceived { get; set; }
}