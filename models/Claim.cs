using System.Collections.Generic;

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
        public int ClaimId { get; set; }

        /// <summary>
        /// Type of claim (Auto, Property, Commercial, Liability, etc.).
        /// </summary>
        public required string ClaimType { get; set; }

        /// <summary>
        /// Severity score (0.0–10.0) used for workload and routing logic.
        /// </summary>
        public decimal SeverityScore { get; set; }

        /// <summary>
        /// Complexity score (0.0–10.0) used for assignment decisions.
        /// </summary>
        public decimal ComplexityScore { get; set; }

        /// <summary>
        /// Jurisdiction where the claim occurred.
        /// </summary>
        public required string Jurisdiction { get; set; }

        /// <summary>
        /// Skill required to handle this claim (Auto, Property, etc.).
        /// </summary>
        public required string RequiredSkill { get; set; }

        /// <summary>
        /// Estimated hours needed to resolve the claim.
        /// </summary>
        public int EstimatedHours { get; set; }

        /// <summary>
        /// Current status (New, Assigned, In Progress, Closed, etc.).
        /// </summary>
        public required string Status { get; set; }

        /// <summary>
        /// Navigation property for all assignments linked to this claim.
        /// </summary>
        public required ICollection<Assignment> Assignments { get; set; }

        /// <summary>
        /// Navigation property for performance history records.
        /// </summary>
        public required ICollection<PerformanceHistory> PerformanceHistory { get; set; }
    }
}
