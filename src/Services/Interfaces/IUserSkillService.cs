using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using src.Modules.Dtos.UserSkills.Input;
using src.Modules.Dtos.UserSkills.Output;

namespace src.Services.Interfaces
{
    public interface IUserSkillService
    {
        public Task<UserSkillGroupedOutputDto> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        public Task<CreateUserSkillOutputDto> CreateAsync(Guid userId, CreateUserSkillInputDto createUserSkillDto, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid userId, Guid skillId, CancellationToken cancellationToken = default);
    }
}