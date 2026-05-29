using System;

namespace AdjusterOptimizerAPI.Models
{
    /// <summary>
    /// Represents historical performance data for an adjuster on a specific claim.
    /// Includes cycle time, indemnity paid, litigation/reopen flags, and customer satisfaction.
    /// </summary>
    public class PerformanceHistory
    {
        /// <summary>
        /// Primary key for the PerformanceHistory table.
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// Foreign key referencing the adjuster associated with this record.
        /// </summary>
        public int AdjusterId { get; set; }

        /// <summary>
        /// Foreign key referencing the claim associated with this record.
        /// </summary>
        public int ClaimId { get; set; }

        /// <summary>
        /// Number of days it took to close the claim.
        /// </summary>
        public int CycleTimeDays { get; set; }

        /// <summary>
        /// Total indemnity paid on the claim.
        /// </summary>
        public decimal IndemnityPaid { get; set; }

        /// <summary>
        /// Indicates whether the claim was reopened (0 = No, 1 = Yes).
        /// </summary>
        public int ReopenFlag { get; set; }

        /// <summary>
        /// Indicates whether the claim went into litigation (0 = No, 1 = Yes).
        /// </summary>
        public int LitigationFlag { get; set; }

        /// <summary>
        /// Customer satisfaction score (0.0–10.0).
        /// </summary>
        public decimal CustomerSatisfaction { get; set; }

        /// <summary>
        /// Navigation property for the related adjuster.
        /// </summary>
        public Adjuster? Adjuster { get; set; }

        /// <summary>
        /// Navigation property for the related claim.
        /// </summary>
        public Claim? Claim { get; set; }
    }
}
