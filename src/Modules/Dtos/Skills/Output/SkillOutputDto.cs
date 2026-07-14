using src.Modules.Dtos;

namespace Modules.Dtos.Skills.Output
{
    public sealed class SkillOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string NormalizedName { get; init; }
        public string Category { get; init; }
    }
}