
using System.Linq;
using src.Modules.Dtos.Users.Output;
using src.Modules.Dtos.UserSkills.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class UserMapper
    {
        public static UserOutputDto MapToDto(this User user)
        {
            return new UserOutputDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Location = user.Location.MapToDto(),
                PreferredWorkMode = user.PreferredWorkMode,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Skills = [.. user.UserSkills.Select(us => new UserSkillItemDto
                {
                    Skill = us.Skill.MapToDto(),
                    Level = us.Level,
                })]
            };
        }
    }
}