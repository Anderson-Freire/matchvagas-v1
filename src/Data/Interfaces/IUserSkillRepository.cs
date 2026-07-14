using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IUserSkillRepository
    {
        public Task<IReadOnlyList<UserSkill>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<UserSkill> GetByUserIdAndSkillIdAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default);
        public Task CreateAsync(UserSkill userSkill, CancellationToken cancellationToken = default);
        public Task DeleteAsync(UserSkill userSkill, CancellationToken cancellationToken = default);
    }
}