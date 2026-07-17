using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Entities;

namespace src.Data.Interfaces
{
    public interface IJobBenefitRepository
    {
        public Task<IReadOnlyList<JobBenefit>> GetAllByJobIdAsync(Guid jobId, CancellationToken cancellationToken = default);
        public Task<JobBenefit> GetByJobIdAndBenefitIdAsync(Guid jobId, Guid benefitId, CancellationToken cancellationToken = default);
        public Task CreateAsync(JobBenefit jobBenefit, CancellationToken cancellationToken = default);
        public Task DeleteAsync(JobBenefit jobBenefit, CancellationToken cancellationToken = default);
    }
}