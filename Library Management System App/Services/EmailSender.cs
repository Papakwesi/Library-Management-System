using Microsoft.AspNetCore.Identity.UI.Services;

namespace Library_Management_System_App.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // For now, do nothing — just simulate success
            Console.WriteLine($"Email to {email}: {subject}");
            return Task.CompletedTask;
        }
    }
}