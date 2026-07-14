using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class UserSkillRepository(AppDbContext context) : IUserSkillRepository
    {
        public async Task<IReadOnlyList<UserSkill>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
            => await context.UserSkills
                .Include(us => us.User)
                .Include(us => us.Skill)
                .Where(us => us.UserId == userId)
                .ToListAsync(cancellationToken);

        public async Task<UserSkill> GetByUserIdAndSkillIdAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default)
            => await context.UserSkills
                .Include(us => us.User)
                .Include(us => us.Skill)
                .SingleOrDefaultAsync(us => us.UserId == userId && us.SkillId == skillId, cancellationToken);

        public async Task CreateAsync(UserSkill userSkill, CancellationToken cancellationToken = default)
        {
            context.UserSkills.Add(userSkill);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(userSkill).State = EntityState.Detached;
        }

        public async Task DeleteAsync(UserSkill userSkill, CancellationToken cancellationToken = default)
        {
            context.UserSkills.Remove(userSkill);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}