using System.Collections.Generic;
using src.Modules.Dtos.Users.Output;

namespace src.Modules.Dtos.Applications.Output
{
    public sealed class ApplicationGroupedOutputDto
    {
        public UserOutputDto User { get; init; }
        public List<ApplicationItemDto> Applications { get; init; }
    }
}