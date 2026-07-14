using src.Modules.Enums;

namespace src.Modules.Dtos.Applications.Input
{
    public sealed class UpdateApplicationInputDto
    {
        public ApplicationStatus? Status { get; init; }
        public string Notes { get; init; }
    }
}