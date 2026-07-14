using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.JobMatches.Input;
using src.Modules.Dtos.JobMatches.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class JobMatchService(
        IJobMatchRepository jobMatchRepository,
        IUserRepository userRepository,
        IJobRepository jobRepository) : IJobMatchService
    {
        public async Task<JobMatchGroupedOutputDto> GetAllByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var jobMatches = await jobMatchRepository.GetAllByUserIdAsync(userId, cancellationToken);

            if (!jobMatches.Any())
                throw new KeyNotFoundException("Nenhum match encontrado para esse usuário.");

            return jobMatches.MapToGroupedDto();
        }

        public async Task<JobMatchOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var jobMatch = await jobMatchRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Match {id} não encontrado.");
            return jobMatch.MapToDto();
        }

        public async Task<CreateJobMatchOutputDto> CreateAsync(Guid userId, CreateJobMatchInputDto createJobMatchDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(userId, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado.");

            var job = await jobRepository.GetByIdAsync(createJobMatchDto.JobId, cancellationToken)
                ?? throw new KeyNotFoundException("Vaga não encontrada.");

            var matchExists = await jobMatchRepository.GetByUserIdAndJobIdAsync(userId, createJobMatchDto.JobId, cancellationToken);
            if (matchExists != null)
                throw new Exception("Match já existe para esse usuário e vaga.");

            var jobMatch = createJobMatchDto.MapToEntity();
            jobMatch.UserId = userId;

            await jobMatchRepository.CreateAsync(jobMatch, cancellationToken);
            var jobMatchWithRelations = await jobMatchRepository.GetByIdAsync(jobMatch.Id, cancellationToken);
            return jobMatchWithRelations.MapToCreateDto();
        }

        public async Task<UpdateJobMatchOutputDto> UpdateAsync(Guid id, UpdateJobMatchInputDto updateJobMatchDto,
            CancellationToken cancellationToken = default)
        {
            var jobMatch = await jobMatchRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Match {id} não encontrado.");

            jobMatch.MapToEntity(updateJobMatchDto);
            await jobMatchRepository.UpdateAsync(jobMatch, cancellationToken);

            var jobMatchWithRelations = await jobMatchRepository.GetByIdAsync(jobMatch.Id, cancellationToken);
            return jobMatchWithRelations.MapToUpdateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var jobMatch = await jobMatchRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Match {id} não encontrado.");

            await jobMatchRepository.DeleteAsync(jobMatch, cancellationToken);
        }
    }
}