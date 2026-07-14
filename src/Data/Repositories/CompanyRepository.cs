using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class CompanyRepository(AppDbContext context) : ICompanyRepository
    {
        public async Task<Company> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Companies.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Companies.ToListAsync(cancellationToken);

        public async Task CreateAsync(Company company, CancellationToken cancellationToken = default)
        {
            context.Companies.Add(company);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Company company, CancellationToken cancellationToken = default)
        {
            context.Companies.Update(company);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Company company, CancellationToken cancellationToken = default)
        {
            context.Companies.Remove(company);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Company> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default)
            => await context.Companies.SingleOrDefaultAsync(c => c.NormalizedName == normalizedName, cancellationToken);

        public async Task<Company> GetByWebsiteAsync(string website, CancellationToken cancellationToken = default)
            => await context.Companies.FirstOrDefaultAsync(c => c.Website == website, cancellationToken);
    }
}