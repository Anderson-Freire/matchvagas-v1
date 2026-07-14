using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task CreateAsync(User user, CancellationToken cancellationToken = default);
        public Task UpdateAsync(User user, CancellationToken cancellationToken = default);
        public Task DeleteAsync(User user, CancellationToken cancellationToken = default);
    }
}