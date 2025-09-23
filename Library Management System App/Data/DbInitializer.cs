using Library_Management_System_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Library_Management_System_App.Data
{
    public class DbInitializer
    {
        public static async Task SeedAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // 1. Define roles
            string[] roleNames = { "SuperAdmin", "Admin", "Employee" };

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2. Create default SuperAdmin user if not exists
            var superAdminEmail = "superadmin@inventory.com";
            var defaultPassword = "Superadmin@123";

            var superAdmin = await userManager.FindByEmailAsync(superAdminEmail);

            if (superAdmin == null)
            {
                superAdmin = new ApplicationUser
                {
                    UserName = superAdminEmail,
                    Email = superAdminEmail,
                    EmailConfirmed = true,
                    DisplayName = "Super Administrator",
                    AvatarUrl = "/images/default-avatar.png"
                };

                var result = await userManager.CreateAsync(superAdmin, defaultPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
            }
            else
            {
                // Make sure user has the SuperAdmin role
                if (!await userManager.IsInRoleAsync(superAdmin, "SuperAdmin"))
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
            }
        }
    }
}
