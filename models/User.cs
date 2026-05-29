using System.ComponentModel.DataAnnotations;

namespace AdjusterOptimizerAPI.Models
{
    /// <summary>
    /// Represents a system user who can register, log in,
    /// and access application features based on assigned role.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key for the Users table.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Username used for authentication.
        /// </summary>
        [Required]
        public required string Username { get; set; }

        /// <summary>
        /// Hashed password stored securely in the database.
        /// </summary>
        [Required]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// User role (Admin, Adjuster, Supervisor, etc.).
        /// Determines access permissions.
        /// </summary>
        [Required]
        public required string Role { get; set; }

        /// <summary>
        /// Email address used for notifications and password recovery.
        /// </summary>
        [Required]
        public required string Email { get; set; }

        /// <summary>
        /// Validates password complexity rules for registration
        /// and password changes.
        /// </summary>
        /// <param name="password">Raw password entered by the user.</param>
        /// <returns>True if password meets all complexity requirements.</returns>
        public static bool ValidatePassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => "!@#$%^&*".Contains(ch));
        }
    }
}
