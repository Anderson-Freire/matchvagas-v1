using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using src.Data.Interfaces;
using src.Modules.Dtos.UserSkills.Input;
using src.Modules.Dtos.UserSkills.Output;
using src.Modules.Mappers;
using src.Modules.Mappers.UserSkills;
using src.Services.Interfaces;

namespace src.Services
{
    public sealed class UserSkillService(
        IUserSkillRepository userSkillRepository,
        IUserRepository userRepository,
        ISkillRepository skillRepository) : IUserSkillService
    {
        public async Task<UserSkillGroupedOutputDto> GetAllByUserIdAsync(Guid userId,
            CancellationToken cancellationToken = default)
        {
            var userSkills = await userSkillRepository.GetAllByUserIdAsync(userId, cancellationToken);

            if (!userSkills.Any())
                throw new KeyNotFoundException("Nenhuma skill encontrada para essa vaga.");

            return userSkills.MapToGroupedDto();
        }

        public async Task<CreateUserSkillOutputDto> CreateAsync(Guid userId, CreateUserSkillInputDto createUserSkillDto,
            CancellationToken cancellationToken = default)
        {
            var user = await userRepository.GetByIdAsync(userId, cancellationToken)
                ?? throw new KeyNotFoundException("Usuário não encontrado.");

            var skill = await skillRepository.GetByIdAsync(createUserSkillDto.SkillId, cancellationToken)
                ?? throw new KeyNotFoundException("Competência não encontrada.");

            var userSkillExists = await userSkillRepository.GetByUserIdAndSkillIdAsync(userId, createUserSkillDto.SkillId, cancellationToken);
            if (userSkillExists != null)
                throw new Exception("Usuário já possui essa competência.");

            var userSkill = createUserSkillDto.MapToEntity();
            userSkill.UserId = userId;

            await userSkillRepository.CreateAsync(userSkill, cancellationToken);
            var userSkillWithRelations = await userSkillRepository.GetByUserIdAndSkillIdAsync(userId, createUserSkillDto.SkillId, cancellationToken);
            return userSkillWithRelations.MapToCreateDto();
        }

        public async Task DeleteAsync(Guid userId, Guid skillId,
            CancellationToken cancellationToken = default)
        {
            var userSkill = await userSkillRepository.GetByUserIdAndSkillIdAsync(userId, skillId, cancellationToken)
                ?? throw new KeyNotFoundException("Competência não encontrada para esse usuário.");

            await userSkillRepository.DeleteAsync(userSkill, cancellationToken);
        }
    }
}