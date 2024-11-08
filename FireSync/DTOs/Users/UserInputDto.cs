using FireSync.Enums;

namespace FireSync.DTOs.Users
{
    public class UserInputDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
}
