using src.Modules.Dtos.Users.Input;
using src.Modules.Dtos.Users.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateUserMapper
    {
        public static User MapToEntity(this CreateUserInputDto createUserInputDto)
        {
            return new User
            {
                Name = createUserInputDto.Name,
                Email = createUserInputDto.Email,
                LocationId = createUserInputDto.LocationId,
                PreferredWorkMode = createUserInputDto.PreferredWorkMode,
            };
        }

        public static CreateUserOutputDto MapToCreateDto(this User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Location = user.Location.MapToDto(),
            PreferredWorkMode = user.PreferredWorkMode,
            CreatedAt = user.CreatedAt
        };

    }
}