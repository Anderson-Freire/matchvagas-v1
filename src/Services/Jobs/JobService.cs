using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.Jobs.Input;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class JobService(IJobRepository jobRepository, ICompanyRepository companyRepository) : IJobService
    {
        private static readonly string[] _validWorkModes = ["remote", "hybrid", "onsite"];
        private static readonly string[] _validSeniorities = ["junior", "mid", "senior", "lead"];
        private static readonly string[] _validContractTypes = ["clt", "pj", "freelance", "internship"];

        public async Task<IReadOnlyList<JobOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await jobRepository.GetAllAsync(cancellationToken))
            .Select(x => x.MapToDto())];
        }

        public async Task<JobOutputDto> GetByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var job = await jobRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Trabalho {id}, não encontrado.");
            return job.MapToDto();
        }

        public async Task<CreateJobOutputDto> CreateAsync(CreateJobInputDto createJobDto,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(createJobDto.Title))
                throw new ArgumentException("Título é obrigatório.");

            var company = await companyRepository.GetByIdAsync(createJobDto.CompanyId, cancellationToken)
                ?? throw new KeyNotFoundException("Empresa não encontrada.");

            var jobExists = await jobRepository.GetByOriginalUrlAsync(createJobDto.OriginalUrl, cancellationToken);
            if (jobExists != null) throw new Exception("Essa vaga já foi cadastrada.");

            if (createJobDto.WorkMode != null && !_validWorkModes.Contains(createJobDto.WorkMode))
                throw new ArgumentException($"WorkMode inválido. Valores aceitos: {string.Join(", ", _validWorkModes)}");

            if (createJobDto.Seniority != null && !_validSeniorities.Contains(createJobDto.Seniority))
                throw new ArgumentException($"Seniority inválido. Valores aceitos: {string.Join(", ", _validSeniorities)}");

            if (createJobDto.ContractType != null && !_validContractTypes.Contains(createJobDto.ContractType))
                throw new ArgumentException($"ContractType inválido. Valores aceitos: {string.Join(", ", _validContractTypes)}");

            var newJob = createJobDto.MapToEntity();
            await jobRepository.CreateAsync(newJob, cancellationToken);
            var jobWithCompany = await jobRepository.GetByIdAsync(newJob.Id, cancellationToken);
            return jobWithCompany.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var job = await jobRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Trabalho {id}, não encontrado.");
            await jobRepository.DeleteAsync(job, cancellationToken);
        }
    }
}