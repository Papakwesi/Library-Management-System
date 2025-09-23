using Microsoft.AspNetCore.Identity;

namespace Library_Management_System_App.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
