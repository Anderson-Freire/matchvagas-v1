using System;

namespace src.Modules.Dtos.Applications.Input
{
    public sealed class CreateApplicationInputDto
    {
        public Guid JobId { get; init; }
        public string Notes { get; init; }
    }
}