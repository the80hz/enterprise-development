namespace Staff.Domain;

public class UnionBenefit
{
    public int UnionBenefitId { get; set; }
    public BenefitType BenefitType { get; set; }
    public DateTime DateReceived { get; set; }
}
