using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data.Interfaces;
using src.Modules.Entities;

namespace src.Data.Repositories
{
    public sealed class LocationRepository(AppDbContext context) : ILocationRepository
    {
        public async Task<IReadOnlyList<Location>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Locations.ToListAsync(cancellationToken);

        public async Task<Location> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await context.Locations
                .SingleOrDefaultAsync(l => l.Id == id, cancellationToken);

        public async Task CreateAsync(Location location, CancellationToken cancellationToken = default)
        {
            context.Locations.Add(location);
            await context.SaveChangesAsync(cancellationToken);
            context.Entry(location).State = EntityState.Detached;
        }

        public async Task DeleteAsync(Location location, CancellationToken cancellationToken = default)
        {
            context.Locations.Remove(location);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}