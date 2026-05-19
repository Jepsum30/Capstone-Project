namespace AdjusterOptimizerAPI.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public required string ClaimType { get; set; }
        public decimal SeverityScore { get; set; }
        public decimal ComplexityScore { get; set; }
        public required string Jurisdiction { get; set; }
        public required string RequiredSkill { get; set; }
        public int EstimatedHours { get; set; }
        public required string Status { get; set; }

        public required ICollection<Assignment> Assignments { get; set; }
        public required ICollection<PerformanceHistory> PerformanceHistory { get; set; }
    }
}
