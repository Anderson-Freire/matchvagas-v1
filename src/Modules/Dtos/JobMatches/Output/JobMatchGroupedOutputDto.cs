using System.Collections.Generic;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.JobMatches.Output
{
    public sealed class JobMatchGroupedOutputDto
    {
        public List<JobMatchItemDto> Matches { get; init; }
    }
}