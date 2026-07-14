using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.Applications.Input;
using src.Modules.Dtos.Applications.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class ApplicationService(
        IApplicationRepository applicationRepository,
        IUserRepository userRepository,
        IJobRepository jobRepository) : IApplicationService
    {
        public async Task<ApplicationGroupedOutputDto> GetAllByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var applications = await applicationRepository.GetAllByUserIdAsync(userId, cancellationToken);

            if (!applications.Any())
                throw new KeyNotFoundException("Nenhuma candidatura encontrada.");

            return applications.MapToGroupedDto();
        }

        public async Task<ApplicationOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var application = await applicationRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidatura {id} não encontrada.");
            return application.MapToDto();
        }

        public async Task<CreateApplicationOutputDto> CreateAsync(Guid userId, CreateApplicationInputDto createApplicationDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(userId, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado.");

            var job = await jobRepository.GetByIdAsync(createApplicationDto.JobId, cancellationToken)
                ?? throw new KeyNotFoundException("Vaga não encontrada.");

            var applicationExists = await applicationRepository.GetByUserIdAndJobIdAsync(userId, createApplicationDto.JobId, cancellationToken);
            if (applicationExists != null)
                throw new Exception("Usuário já candidatou-se a essa vaga.");

            var application = createApplicationDto.MapToEntity();
            application.UserId = userId;

            await applicationRepository.CreateAsync(application, cancellationToken);
            var applicationWithRelations = await applicationRepository.GetByIdAsync(application.Id, cancellationToken);
            return applicationWithRelations.MapToCreateDto();
        }

        public async Task<UpdateApplicationOutputDto> UpdateAsync(Guid id, UpdateApplicationInputDto updateApplicationDto,
            CancellationToken cancellationToken = default)
        {
            var application = await applicationRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidatura {id} não encontrada.");

            application.MapToEntity(updateApplicationDto);
            await applicationRepository.UpdateAsync(application, cancellationToken);

            var applicationWithRelations = await applicationRepository.GetByIdAsync(application.Id, cancellationToken);
            return applicationWithRelations.MapToUpdateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var application = await applicationRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidatura {id} não encontrada.");

            await applicationRepository.DeleteAsync(application, cancellationToken);
        }
    }
}
