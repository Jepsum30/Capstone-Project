using System.ComponentModel.DataAnnotations.Schema;

namespace AdjusterOptimizerAPI.Models
{
    /// <summary>
    /// Represents a claim assignment made by the system or a supervisor.
    /// Includes metadata such as score, explanation, and assignment date.
    /// </summary>
    public class Assignment
    {
        [Column("ASSIGNMENT_ID")]
        public int AssignmentId { get; set; }

        [Column("CLAIM_ID")]
        public int ClaimId { get; set; }

        [Column("ADJUSTER_ID")]
        public int AdjusterId { get; set; }

        [Column("ASSIGNMENT_DATE")]
        public DateTime AssignmentDate { get; set; }

        [Column("SCORE")]
        public decimal Score { get; set; }

        [Column("ASSIGNED_BY")]
        public required string AssignedBy { get; set; }

        [Column("EXPLANATION")]
        public required string Explanation { get; set; }

        // ⭐ REQUIRED NAVIGATION PROPERTIES ⭐
        public required Adjuster Adjuster { get; set; }
        public required Claim Claim { get; set; }
    }
}
