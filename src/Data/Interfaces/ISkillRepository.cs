using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface ISkillRepository
    {
        public Task<Skill> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<Skill>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task CreateAsync(Skill skill, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Skill skill, CancellationToken cancellationToken = default);
        public Task<Skill> GetByNormalizedNameAsync(string normalizedName, CancellationToken cancellationToken = default);
    }
}