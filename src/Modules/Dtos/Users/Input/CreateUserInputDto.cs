using System;
using src.Modules.Enums;

namespace src.Modules.Dtos.Users.Input
{
    public sealed class CreateUserInputDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public WorkMode PreferredWorkMode { get; init; }

        public Guid LocationId { get; init; }
    }
}