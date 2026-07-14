using System;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.FavoriteJobs.Output
{
    public class CreateFavoriteJobOutputDto
    {
        public UserOutputDto User { get; init; }
        public JobOutputDto Job { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}