using Netflix.API.Application.Enums;
using Netflix.API.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Netflix.API.Identity.Seeds
{
    public static class DefaultRole
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole>roles)
        {
            //Seed Roles
            await roles.CreateAsync(new IdentityRole(RolesEnum.Administrator.ToString()));
            await roles.CreateAsync(new IdentityRole(RolesEnum.Basic.ToString()));


        }
    }
}
