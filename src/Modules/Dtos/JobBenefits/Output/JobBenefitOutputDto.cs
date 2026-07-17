using System;
using src.Modules.Dtos.Benefits.Output;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.JobBenefits.Output
{
    public class JobBenefitOutputDto
    {
        public JobOutputDto Job { get; init; }
        public BenefitOutputDto Benefit { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}