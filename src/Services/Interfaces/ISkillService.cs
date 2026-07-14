using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Modules.Dtos.Skills.Output;
using src.Modules.Dtos.Skills.Input;
using src.Modules.Dtos.Skills.Output;

namespace src.Services.Interfaces
{
    public interface ISkillService
    {
        public Task<IReadOnlyList<SkillOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
        public Task<CreateSkillOutputDto> CreateAsync(CreateSkillInputDto createSkillDto,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}