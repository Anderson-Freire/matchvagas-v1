using System;

namespace src.Modules.Dtos.JobMatches.Input
{
    public sealed class CreateJobMatchInputDto
    {
        public Guid JobId { get; init; }
        public decimal MatchScore { get; init; }
        public ScoreBreakdownDto ScoreBreakdown { get; init; }
        public DateTime? ExpiresAt { get; init; }
    }
}
