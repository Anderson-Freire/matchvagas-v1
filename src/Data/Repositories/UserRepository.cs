using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Users
            .Include(u => u.Location)
            .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Users
            .Include(u => u.Location)
            .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
            .ToListAsync(cancellationToken);

        public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(user).State = EntityState.Detached;
        }

        public async Task DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}