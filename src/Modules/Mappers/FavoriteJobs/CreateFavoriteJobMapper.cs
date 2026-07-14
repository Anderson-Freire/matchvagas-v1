using src.Modules.Dtos.FavoriteJobs.Input;
using src.Modules.Dtos.FavoriteJobs.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateFavoriteJobMapper
    {
        public static FavoriteJob MapToEntity(this CreateFavoriteJobInputDto
            createFavoriteJobInputDto)
        {
            return new FavoriteJob
            {
                JobId = createFavoriteJobInputDto.JobId,
            };
        }

        public static CreateFavoriteJobOutputDto MapToCreateDto(this FavoriteJob favoriteJob) => new()
        {
            User = favoriteJob.User.MapToDto(),
            Job = favoriteJob.Job.MapToDto(),
            CreatedAt = favoriteJob.CreatedAt,
        };
    }
}