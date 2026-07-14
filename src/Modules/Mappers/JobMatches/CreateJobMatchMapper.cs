using System.Text.Json;
using src.Modules.Dtos.JobMatches.Input;
using src.Modules.Dtos.JobMatches.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateJobMatchMapper
    {
        public static JobMatch MapToEntity(this CreateJobMatchInputDto createJobMatchInputDto)
        {
            return new JobMatch
            {
                JobId = createJobMatchInputDto.JobId,
                MatchScore = createJobMatchInputDto.MatchScore * 100,
                ScoreBreakdown = createJobMatchInputDto.ScoreBreakdown != null
                    ? JsonSerializer.Serialize(createJobMatchInputDto.ScoreBreakdown)
                    : null,
                ExpiresAt = createJobMatchInputDto.ExpiresAt,
            };
        }

        public static CreateJobMatchOutputDto MapToCreateDto(this JobMatch jobMatch) => new()
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