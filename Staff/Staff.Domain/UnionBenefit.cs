using System;
using Staff.Enums;

namespace Staff.Models
{
    public class UnionBenefit
    {
        public int UnionBenefitId { get; set; }
        public BenefitType BenefitType { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
