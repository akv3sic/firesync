using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FireSync.Models
{
    /// <summary>
    /// Represents the application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name of the application user.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the application user.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of birth of the application user.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the address of the application user.
        /// </summary>
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
