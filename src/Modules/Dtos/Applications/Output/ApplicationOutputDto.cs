using System;
using src.Modules.Dtos.Jobs.Output;
using src.Modules.Dtos.Users.Output;
using src.Modules.Enums;

namespace src.Modules.Dtos.Applications.Output
{
    public sealed class ApplicationOutputDto : BaseDto
    {
        public UserOutputDto User { get; init; }
        public JobOutputDto Job { get; init; }
        public ApplicationStatus Status { get; init; }
        public string Notes { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}