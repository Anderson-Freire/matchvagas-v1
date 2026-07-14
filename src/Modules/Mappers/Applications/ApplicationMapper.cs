using System.Collections.Generic;
using System.Linq;
using src.Modules.Dtos.Applications.Output;
using src.Modules.Entities;

namespace src.Modules.Mappers
{
    public static class ApplicationMapper
    {
        public static ApplicationOutputDto MapToDto(this Application application)
        {
            return new ApplicationOutputDto
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

        public static ApplicationGroupedOutputDto MapToGroupedDto(this IEnumerable<Application> applications)
        {
            return new ApplicationGroupedOutputDto
            {
                User = applications.First().User.MapToDto(),
                Applications = [.. applications.Select(a => new ApplicationItemDto
                {
                    Id = a.Id,
                    Job = a.Job.MapToDto(),
                    Status = a.Status,
                    Notes = a.Notes,
                    UpdatedAt = a.UpdatedAt,
                    CreatedAt = a.CreatedAt,
                })]
            };
        }
    }
}