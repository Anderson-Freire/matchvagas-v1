using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Helpers;
using src.Modules.Dtos.Companies.Input;
using src.Modules.Dtos.Companies.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class CompanyService(ICompanyRepository companyRepository) : ICompanyService
    {
        public async Task<IReadOnlyList<CompanyOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await companyRepository.GetAllAsync(cancellationToken))
                .Select(x => x.MapToDto())];
        }

        public async Task<CompanyOutputDto> GetByIdAsync(Guid id,
             CancellationToken cancellationToken = default)
        {
            var company = await companyRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Empresa {id} não encontrada.");
            return company.MapToDto();
        }

        public async Task<CreateCompanyOutputDto> CreateAsync(CreateCompanyInputDto createCompanyDto,
            CancellationToken cancellationToken = default)
        {

            if (string.IsNullOrWhiteSpace(createCompanyDto.Name))
                throw new ArgumentException("Nome é obrigatório.");

            var normalizedName = StringHelper.NormalizeName(createCompanyDto.Name);

            var nameExists = await companyRepository.GetByNormalizedNameAsync(normalizedName, cancellationToken);
            if (nameExists != null)
                throw new Exception("Já existe uma empresa com esse nome.");

            var websiteExists = await companyRepository.GetByWebsiteAsync(createCompanyDto.Website, cancellationToken); // 👈
            if (websiteExists != null)
                throw new Exception("Já existe uma empresa com esse website.");

            var company = createCompanyDto.MapToEntity();
            await companyRepository.CreateAsync(company, cancellationToken);
            return company.MapToCreateDto();
        }

        public async Task<UpdateCompanyOutputDto> UpdateAsync(Guid id, UpdateCompanyInputDto updateCompanyDto,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(updateCompanyDto.Name))
                throw new ArgumentException("Nome é obrigatório.");

            var company = await companyRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Empresa {id} não encontrada.");

            var normalizedName = StringHelper.NormalizeName(updateCompanyDto.Name);

            var nameExists = await companyRepository.GetByNormalizedNameAsync(normalizedName, cancellationToken);
            if (nameExists != null && nameExists.Id != id)
                throw new Exception("Já existe uma empresa com esse nome.");

            if (!string.IsNullOrWhiteSpace(updateCompanyDto.Website))
            {
                var websiteExists = await companyRepository.GetByWebsiteAsync(updateCompanyDto.Website, cancellationToken);
                if (websiteExists != null && websiteExists.Id != id)
                    throw new Exception("Já existe uma empresa com esse website.");
            }

            company.MapToEntity(updateCompanyDto);
            await companyRepository.UpdateAsync(company, cancellationToken);
            return company.MapToUpdateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var company = await companyRepository.GetByIdAsync(id, cancellationToken)
                ?? throw new KeyNotFoundException($"Empresa {id} não encontrada.");

            await companyRepository.DeleteAsync(company, cancellationToken);
        }
    }
}