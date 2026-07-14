using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.FavoriteJobs.Input;
using src.Modules.Dtos.FavoriteJobs.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class FavoriteJobService(
        IFavoriteJobRepository favoriteJobRepository,
        IUserRepository userRepository,
        IJobRepository jobRepository) : IFavoriteJobService
    {
        public async Task<FavoriteJobGroupedOutputDto> GetAllByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var favoriteJobs = await favoriteJobRepository.GetAllByUserIdAsync(userId, cancellationToken);

            if (!favoriteJobs.Any())
                throw new KeyNotFoundException("Nenhuma vaga favorita encontrada.");

            return favoriteJobs.MapToGroupedDto();
        }

        public async Task<CreateFavoriteJobOutputDto> CreateAsync(Guid userId, CreateFavoriteJobInputDto createFavoriteJobDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(userId, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado.");

            var job = await jobRepository.GetByIdAsync(createFavoriteJobDto.JobId, cancellationToken)
                ?? throw new KeyNotFoundException("Vaga não encontrada.");

            var favoriteJobExists = await favoriteJobRepository.GetByUserIdAndJobIdAsync(userId, createFavoriteJobDto.JobId, cancellationToken);
            if (favoriteJobExists != null)
                throw new Exception("Vaga já está nos favoritos.");

            var favoriteJob = createFavoriteJobDto.MapToEntity();
            favoriteJob.UserId = userId;

            await favoriteJobRepository.CreateAsync(favoriteJob, cancellationToken);
            var favoriteJobWithRelations = await favoriteJobRepository.GetByUserIdAndJobIdAsync(userId, createFavoriteJobDto.JobId, cancellationToken);
            return favoriteJobWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid userId, Guid jobId,
            CancellationToken cancellationToken = default)
        {
            var favoriteJob = await favoriteJobRepository.GetByUserIdAndJobIdAsync(userId, jobId, cancellationToken)
                ?? throw new KeyNotFoundException("Vaga não encontrada nos favoritos.");

            await favoriteJobRepository.DeleteAsync(favoriteJob, cancellationToken);
        }
    }
}