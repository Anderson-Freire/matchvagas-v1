using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.FavoriteJobs.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class FavoriteJobMapper
    {
        public static FavoriteJobOutputDto MapToDto(this FavoriteJob favoriteJob)
        {
            return new FavoriteJobOutputDto
            {
                User = favoriteJob.User.MapToDto(),
                Job = favoriteJob.Job.MapToDto(),
                CreatedAt = favoriteJob.CreatedAt,
            };
        }

        public static FavoriteJobGroupedOutputDto MapToGroupedDto(this IEnumerable<FavoriteJob> favoriteJobs)
        {
            return new FavoriteJobGroupedOutputDto
            {
                User = favoriteJobs.First().User.MapToDto(),
                FavoriteJobs = [.. favoriteJobs.Select(fj => new FavoriteJobItemOutputDto
                {
                    Job = fj.Job.MapToDto(),
                    CreatedAt = fj.CreatedAt,
                })]
            };
        }
    }
}