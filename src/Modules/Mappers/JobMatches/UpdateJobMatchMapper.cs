using System;
using System.Text.Json;
using src.Modules.Dtos.JobMatches.Input;
using src.Modules.Dtos.JobMatches.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class UpdateJobMatchMapper
    {
        public static void MapToEntity(this JobMatch jobMatch, UpdateJobMatchInputDto updateJobMatchInputDto)
        {
            if (updateJobMatchInputDto.MatchScore.HasValue)
                jobMatch.MatchScore = updateJobMatchInputDto.MatchScore.Value * 100;

            if (updateJobMatchInputDto.ScoreBreakdown != null)
                jobMatch.ScoreBreakdown = JsonSerializer.Serialize(updateJobMatchInputDto.ScoreBreakdown);

            if (updateJobMatchInputDto.IsViewed.HasValue)
                jobMatch.IsViewed = updateJobMatchInputDto.IsViewed.Value;

            if (updateJobMatchInputDto.ExpiresAt.HasValue)
                jobMatch.ExpiresAt = updateJobMatchInputDto.ExpiresAt.Value;

            jobMatch.AnalyzedAt = DateTime.Now;
        }

        public static UpdateJobMatchOutputDto MapToUpdateDto(this JobMatch jobMatch) => new()
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
}