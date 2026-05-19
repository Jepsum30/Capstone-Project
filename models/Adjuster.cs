namespace AdjusterOptimizerAPI.Models
{
    public class Adjuster
    {
        public int AdjusterId { get; set; }
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public int SkillLevel { get; set; }
        public required string Specialty { get; set; }
        public required string Jurisdiction { get; set; }
        public int Workload { get; set; }
        public decimal PerformanceScore { get; set; }
        public int TenureYears { get; set; }

        public required ICollection<Assignment> Assignments { get; set; }
        public required ICollection<PerformanceHistory> PerformanceHistory { get; set; }
    }
}
