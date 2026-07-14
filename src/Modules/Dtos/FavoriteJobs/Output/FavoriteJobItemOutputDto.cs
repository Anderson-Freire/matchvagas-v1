using System;
using src.Modules.Dtos.Jobs.Output;

namespace src.Modules.Dtos.FavoriteJobs.Output
{
    public class FavoriteJobItemOutputDto
    {
        public JobOutputDto Job { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}