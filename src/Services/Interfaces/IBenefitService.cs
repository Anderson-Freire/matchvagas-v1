using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Benefits.Input;
using src.Modules.Dtos.Benefits.Output;

namespace src.Services.Interfaces
{
    public interface IBenefitService
    {
        public Task<IReadOnlyList<BenefitOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
        public Task<CreateBenefitOutputDto> CreateAsync(CreateBenefitInputDto createBenefitDto,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}