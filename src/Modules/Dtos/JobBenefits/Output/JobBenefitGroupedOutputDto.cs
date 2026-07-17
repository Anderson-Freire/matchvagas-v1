using System.Collections.Generic;
using src.Modules.Dtos.Benefits.Output;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.JobBenefits.Output
{
    public class JobBenefitGroupedOutputDto
    {
        public JobOutputDto Job { get; init; }
        public List<BenefitOutputDto> Benefits { get; init; }
    }
}