namespace src.Modules.Dtos.Skills.Output
{
    public sealed class CreateSkillOutputDto : BaseDto
    {
        public string Name { get; init; }
        public string NormalizedName { get; init; }
        public string Category { get; init; }
    }
}