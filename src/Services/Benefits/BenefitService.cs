using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Helpers;
using src.Modules.Dtos.Benefits.Input;
using src.Modules.Dtos.Benefits.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class BenefitService(IBenefitRepository benefitRepository) : IBenefitService
    {
        public async Task<IReadOnlyList<BenefitOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await benefitRepository.GetAllAsync(cancellationToken))
                .Select(x => x.MapToDto())];
        }

        public async Task<CreateBenefitOutputDto> CreateAsync(CreateBenefitInputDto createBenefitDto,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(createBenefitDto.Name))
                throw new ArgumentException("Nome é obrigatório.");

            var normalizedName = StringHelper.NormalizeName(createBenefitDto.Name);

            var nameExists = await benefitRepository.GetByNormalizedNameAsync(normalizedName, cancellationToken);
            if (nameExists != null)
                throw new Exception("Já existe um benefício com esse nome.");

            var benefit = createBenefitDto.MapToEntity();
            await benefitRepository.CreateAsync(benefit, cancellationToken);
            return benefit.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var benefit = await benefitRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new KeyNotFoundException($"Benefício {id} não encontrada.");

            await benefitRepository.DeleteAsync(benefit, cancellationToken);
        }

    }
}