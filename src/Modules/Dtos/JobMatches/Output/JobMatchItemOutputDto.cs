using System;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.JobMatches.Output
{
    public sealed class JobMatchItemDto : BaseDto
    {
        public JobOutputDto Job { get; init; }
        public decimal MatchScore { get; init; }
        public string ScoreBreakdown { get; init; }
        public bool IsViewed { get; init; }
        public DateTime AnalyzedAt { get; init; }
        public DateTime? ExpiresAt { get; init; }
    }
}