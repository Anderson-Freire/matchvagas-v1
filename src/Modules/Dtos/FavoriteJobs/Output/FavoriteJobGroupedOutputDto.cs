using System.Collections.Generic;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.FavoriteJobs.Output
{
    public class FavoriteJobGroupedOutputDto
    {
        public UserOutputDto User { get; init; }
        public List<FavoriteJobItemOutputDto> FavoriteJobs { get; init; }
    }
}