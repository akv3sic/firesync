namespace FireSync.DTOs
{
    /// <summary>
    /// Represents the user output data transfer object.
    /// </summary>
    public class UserOutputDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserOutputDto"/> class.
        /// </summary>
        public UserOutputDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserOutputDto"/> class.
        /// </summary>
        /// <param name="user">The user output data transfer object.</param>"
        public UserOutputDto(UserOutputDto user)
        {
            this.Id = user.Id;
            this.Username = user.Username;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Roles = new List<string>(user.Roles);
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();

        /// <summary>
        /// Gets a value indicating whether the user is an admin.
        /// </summary>
        public bool IsAdmin => this.Roles.Contains(Enums.Roles.Admin.ToString());
    }
}