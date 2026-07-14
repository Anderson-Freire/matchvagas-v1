using src.Modules.Dtos.Applications.Input;
using src.Modules.Dtos.Applications.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class CreateApplicationMapper
    {
        public static Application MapToEntity(this CreateApplicationInputDto
            createApplicationInputDto)
        {
            return new Application
            {
                JobId = createApplicationInputDto.JobId,
                Notes = createApplicationInputDto.Notes,
            };
        }

        public static CreateApplicationOutputDto MapToCreateDto(this Application application) => new()
        {
            Id = application.Id,
            User = application.User.MapToDto(),
            Job = application.Job.MapToDto(),
            Status = application.Status,
            Notes = application.Notes,
            CreatedAt = application.CreatedAt,
        };
    }
}