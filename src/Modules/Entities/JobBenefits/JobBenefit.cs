using System;

namespace src.Modules.Entities
{
    public class JobBenefit
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid BenefitId { get; set; }
        public Benefit Benefit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}