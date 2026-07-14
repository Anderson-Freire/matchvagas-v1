using System;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.FavoriteJobs.Input;
using src.Modules.Dtos.FavoriteJobs.Output;

namespace src.Services.Interfaces
{
    public interface IFavoriteJobService
    {
        public Task<FavoriteJobGroupedOutputDto> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<CreateFavoriteJobOutputDto> CreateAsync(Guid userId, CreateFavoriteJobInputDto createFavoriteJobDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid userId, Guid jobId, CancellationToken cancellationToken = default);
    }
}