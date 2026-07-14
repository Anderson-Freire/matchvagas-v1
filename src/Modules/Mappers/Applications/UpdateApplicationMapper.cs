using System;
using src.Modules.Dtos.Applications.Input;
using src.Modules.Dtos.Applications.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class UpdateApplicationMapper
    {
        public static void MapToEntity(this Application application,
            UpdateApplicationInputDto updateApplicationInputDto)
        {
            if (updateApplicationInputDto.Status.HasValue)
                application.Status = updateApplicationInputDto.Status.Value;

            if (!string.IsNullOrWhiteSpace(updateApplicationInputDto.Notes))
                application.Notes = updateApplicationInputDto.Notes;

            application.UpdatedAt = DateTime.Now;
        }

        public static UpdateApplicationOutputDto MapToUpdateDto(this Application application) => new()
        {
            Id = application.Id,
            User = application.User.MapToDto(),
            Job = application.Job.MapToDto(),
            Status = application.Status,
            Notes = application.Notes,
            CreatedAt = application.CreatedAt,
            UpdatedAt = application.UpdatedAt,
        };
    }
}