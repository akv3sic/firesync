using Microsoft.AspNetCore.Identity;
using FireSync.Models;

namespace FireSync.Components.Account
{
    /// <summary>
    /// Represents the identity email sender.
    /// </summary>
    internal sealed class IdentityEmailSender : IEmailSender<ApplicationUser>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityEmailSender"/> class.
        /// </summary>
        public IdentityEmailSender()
        {
        }

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            throw new NotImplementedException();

        /// <inheritdoc/>
        /// <exception cref="Exception">Thrown when an error occurred while sending the email.</exception>"
        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            try
            {
                // TODO: Implement email sending logic here
                await Task.CompletedTask; // Placeholder for actual email sending logic
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while sending the email.", ex);
            }
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            throw new NotImplementedException();
    }
}
