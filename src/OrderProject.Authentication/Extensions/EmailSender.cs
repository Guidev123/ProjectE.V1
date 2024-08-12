using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using OrderProject.Authentication.Data.Users;

namespace OrderProject.Authentication.Extensions
{
    public class EmailSender : IEmailSender<UserRoles>
    {
        public Task SendConfirmationLinkAsync(UserRoles user, string email, string confirmationLink)
        {
            throw new NotImplementedException();
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }

        public Task SendPasswordResetCodeAsync(UserRoles user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }

        public Task SendPasswordResetLinkAsync(UserRoles user, string email, string resetLink)
        {
            throw new NotImplementedException();
        }
    }
}
