using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IJobSkillRepository
    {
        public Task<IReadOnlyList<JobSkill>> GetAllByJobIdAsync(Guid jobId, CancellationToken cancellationToken = default);
        public Task<JobSkill> GetByJobIdAndSkillIdAsync(Guid jobId, Guid skillId, CancellationToken cancellationToken = default);
        public Task CreateAsync(JobSkill jobSkill, CancellationToken cancellationToken = default);
        public Task DeleteAsync(JobSkill jobSkill, CancellationToken cancellationToken = default);
    }
}
