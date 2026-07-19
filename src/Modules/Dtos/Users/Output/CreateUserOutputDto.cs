using System;
using src.Modules.Dtos.Location.Output;
using src.Modules.Enums;

namespace src.Modules.Dtos.Users.Output
{
    public class CreateUserOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public WorkMode PreferredWorkMode { get; init; }
        public LocationOutputDto Location { get; init; }
    }
}