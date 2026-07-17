using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.Companies.Input;
using src.Modules.Dtos.Companies.Output;

namespace src.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<IReadOnlyList<CompanyOutputDto>> GetAllAsync(
            CancellationToken cancellationToken = default);
        public Task<CompanyOutputDto> GetByIdAsync(Guid id,
             CancellationToken cancellationToken = default);
        public Task<CreateCompanyOutputDto> CreateAsync(CreateCompanyInputDto createCompanyDto,
            CancellationToken cancellationToken = default);
        public Task<UpdateCompanyOutputDto> UpdateAsync(Guid id, UpdateCompanyInputDto updateCompanyDto,
            CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}