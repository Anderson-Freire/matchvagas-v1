using System;

namespace src.Modules.Dtos.JobMatches.Input
{
    public sealed class UpdateJobMatchInputDto
    {
        public decimal? MatchScore { get; init; }
        public ScoreBreakdownDto ScoreBreakdown { get; init; }
        public bool? IsViewed { get; init; }
        public DateTime? ExpiresAt { get; init; }
    }
}