using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.JobMatches.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class JobMatchMapper
    {
        public static JobMatchOutputDto MapToDto(this JobMatch jobMatch)
        {
            return new JobMatchOutputDto
            {
                Id = jobMatch.Id,
                Job = jobMatch.Job.MapToDto(),
                MatchScore = jobMatch.MatchScore,
                ScoreBreakdown = jobMatch.ScoreBreakdown,
                IsViewed = jobMatch.IsViewed,
                AnalyzedAt = jobMatch.AnalyzedAt,
                ExpiresAt = jobMatch.ExpiresAt,
                CreatedAt = jobMatch.CreatedAt,
            };
        }

        public static JobMatchGroupedOutputDto MapToGroupedDto(this IEnumerable<JobMatch> jobMatches)
        {
            return new JobMatchGroupedOutputDto
            {
                Matches = [.. jobMatches.Select(jm => new JobMatchItemDto
                {
                    Id = jm.Id,
                    Job = jm.Job.MapToDto(),
                    MatchScore = jm.MatchScore,
                    ScoreBreakdown = jm.ScoreBreakdown,
                    IsViewed = jm.IsViewed,
                    AnalyzedAt = jm.AnalyzedAt,
                    ExpiresAt = jm.ExpiresAt,
                    CreatedAt = jm.CreatedAt,
                })]
            };
        }
    }
}