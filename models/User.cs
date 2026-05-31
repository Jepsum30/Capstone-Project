using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdjusterOptimizerAPI.Models
{
    /// <summary>
    /// Represents a system user who can register, authenticate,
    /// and access application features based on assigned role.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key for the Users table.
        /// Maps to USER_ID in MySQL.
        /// </summary>
       [Column("USER_ID")]
       public int UserId { get; set;}

        /// <summary>
        /// Username used for authentication.
        /// Required for registration and login.
        /// Maps to USERNAME in MySQL.
        /// </summary>
        [Required]
        [Column("USERNAME")]
        public required string Username { get; set; }

        /// <summary>
        /// Hashed password stored securely in the database.
        /// Maps to PASSWORD_HASH in MySQL.
        /// </summary>
        [Required]
        [Column("PASSWORD_HASH")]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// User role (Admin, Adjuster, Supervisor, etc.).
        /// Determines access permissions.
        /// Maps to ROLE in MySQL.
        /// </summary>
        [Required]
        [Column("ROLE")]
        public required string Role { get; set; }

        /// <summary>
        /// Email address used for notifications and password recovery.
        /// Maps to EMAIL in MySQL.
        /// </summary>
        [Required]
        [Column("EMAIL")]
        public required string Email { get; set; }

        /// <summary>
        /// Validates password complexity rules for registration
        /// and password changes.
        /// </summary>
        /// <param name="password">Raw password entered by the user.</param>
        /// <returns>True if password meets all complexity requirements.</returns>
        public static bool ValidatePassword(string password)
        {
            // Enforces strong password rules:
            // - At least 8 characters
            // - Contains uppercase, lowercase, digit, and symbol
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => "!@#$%^&*".Contains(ch));
        }
    }
}
