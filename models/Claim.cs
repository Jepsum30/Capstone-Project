using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdjusterOptimizerAPI.Models
{
    /// <summary>
    /// Represents an insurance claim, including type, severity,
    /// complexity, jurisdiction, required skills, and status.
    /// </summary>
    public class Claim
    {
        /// <summary>
        /// Primary key for the Claims table.
        /// </summary>
        [Column("CLAIM_ID")]
        public int ClaimId { get; set; }

        /// <summary>
        /// Type of claim (Auto, Property, Commercial, Liability, etc.).
        /// </summary>
        [Column("CLAIM_TYPE")]
        public required string ClaimType { get; set; }

        /// <summary>
        /// Severity score (0.0–10.0) used for workload and routing logic.
        /// </summary>
        [Column("SEVERITY_SCORE")]
        public decimal SeverityScore { get; set; }

        /// <summary>
        /// Complexity score (0.0–10.0) used for assignment decisions.
        /// </summary>
        [Column("COMPLEXITY_SCORE")]
        public decimal ComplexityScore { get; set; }

        /// <summary>
        /// Jurisdiction where the claim occurred.
        /// </summary>
        public required string Jurisdiction { get; set; }

        /// <summary>
        /// Skill required to handle this claim (Auto, Property, etc.).
        /// </summary>
        [Column("REQUIRED_SKILL")]
        public required string RequiredSkill { get; set; }

        /// <summary>
        /// Estimated hours needed to resolve the claim.
        /// </summary>
        [Column("ESTIMATED_HOURS")]
        public int EstimatedHours { get; set; }

        /// <summary>
        /// Current status (New, Assigned, In Progress, Closed, etc.).
        /// </summary>
        
        public required string Status { get; set; }

        /// <summary>
        /// Navigation property for all assignments linked to this claim.
        /// </summary>
        public List<Assignment> Assignments { get; set; } = new();
        /// <summary>
        /// Navigation property for performance history records.
        /// </summary>
        public List<PerformanceHistory> PerformanceHistory { get; set; } = new();
    }
}
