using System;
using src.Modules.Dtos.Users.Input;
using src.Modules.Dtos.Users.Output;
using src.Modules.Entities;
using src.Modules.Mappers;

namespace metvagas.src.Modules.Mappers
{
    public static class UpdateUserMapper
    {
        public static void MapToEntity(
            this User user,
            UpdateUserInputDto updateUserInputDto)
        {
            if (!string.IsNullOrWhiteSpace(updateUserInputDto.Name))
                user.Name = updateUserInputDto.Name;

            if (!string.IsNullOrWhiteSpace(updateUserInputDto.Email))
                user.Email = updateUserInputDto.Email;

            if (updateUserInputDto.PreferredWorkMode.HasValue)
                user.PreferredWorkMode = updateUserInputDto.PreferredWorkMode.Value;

            user.UpdatedAt = DateTime.Now;

            if (updateUserInputDto.LocationId.HasValue)
                user.LocationId = updateUserInputDto.LocationId.Value;
        }

        public static UpdateUserOutputDto MapToUpdateDto(this User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Location = user.Location.MapToDto(),
            PreferredWorkMode = user.PreferredWorkMode,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}