using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Modules.Dtos.Skills.Output;
using src.Data.Interfaces;
using src.Helpers;
using src.Modules.Dtos.Skills.Input;
using src.Modules.Dtos.Skills.Output;
using src.Modules.Mappers;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class SkillService(ISkillRepository skillRepository) : ISkillService
    {
        public async Task<IReadOnlyList<SkillOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return [.. (await skillRepository.GetAllAsync(cancellationToken))
                .Select(x => x.MapToDto())];
        }

        public async Task<CreateSkillOutputDto> CreateAsync(CreateSkillInputDto createSkillDto,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(createSkillDto.Name))
                throw new ArgumentException("Nome é obrigatório.");

            var normalizedName = StringHelper.NormalizeName(createSkillDto.Name);

            var nameExists = await skillRepository.GetByNormalizedNameAsync(normalizedName, cancellationToken);
            if (nameExists != null)
                throw new Exception("Já existe uma competência com esse nome.");

            if (string.IsNullOrWhiteSpace(createSkillDto.Category))
                throw new ArgumentException("Categoria é obrigatória.");

            var skill = createSkillDto.MapToEntity();
            await skillRepository.CreateAsync(skill, cancellationToken);
            return skill.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var skill = await skillRepository.GetByIdAsync(id, cancellationToken)
                    ?? throw new KeyNotFoundException($"Empresa {id} não encontrada.");


            await skillRepository.DeleteAsync(skill, cancellationToken);
        }
    }
}