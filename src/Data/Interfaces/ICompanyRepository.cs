using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<Company> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task CreateAsync(Company company, CancellationToken cancellationToken = default);
        public Task UpdateAsync(Company company, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Company company, CancellationToken cancellationToken = default);
        public Task<Company> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default);
        public Task<Company> GetByWebsiteAsync(string website, CancellationToken cancellationToken = default);

    }
}