namespace src.Modules.Dtos.JobMatches.Input
{
    public sealed class ScoreBreakdownDto
    {
        public decimal SkillsMatch { get; init; }
        public decimal LocationMatch { get; init; }
        public decimal SeniorityMatch { get; init; }
        public decimal SalaryMatch { get; init; }
    }
}