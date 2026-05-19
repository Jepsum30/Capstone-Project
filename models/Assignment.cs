namespace AdjusterOptimizerAPI.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int ClaimId { get; set; }
        public int AdjusterId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public decimal Score { get; set; }
        public required string AssignedBy { get; set; }
        public required string Explanation { get; set; }

        public required Adjuster Adjuster { get; set; }
        public required Claim Claim { get; set; }
    }
}
