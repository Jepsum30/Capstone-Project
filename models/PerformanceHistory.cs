namespace AdjusterOptimizerAPI.Models
{
    public class PerformanceHistory
    {
        public int RecordId { get; set; }
        public int AdjusterId { get; set; }
        public int ClaimId { get; set; }
        public int CycleTimeDays { get; set; }
        public decimal IndemnityPaid { get; set; }
        public int ReopenFlag { get; set; }
        public int LitigationFlag { get; set; }
        public decimal CustomerSatisfaction { get; set; }

        public Adjuster? Adjuster { get; set; }
        public Claim? Claim { get; set; }
    }
}
