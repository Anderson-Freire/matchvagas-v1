using System;
using src.Modules.Dtos.Location.Output;
using src.Modules.Enums;

namespace src.Modules.Dtos.Users.Output
{
    public sealed class UpdateUserOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public WorkMode PreferredWorkMode { get; init; }
        public DateTime UpdatedAt { get; init; }
        public LocationOutputDto Location { get; init; }
    }
}