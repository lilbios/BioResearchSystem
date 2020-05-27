using bioResearchSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Common
{
    public class RolesInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            var adminRole = Roles.Admin.ToString();
            var userRole = Roles.User.ToString();
            if (await roleManager.FindByNameAsync(adminRole) is null)
            {

                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(userRole) is null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }

            if (await userManager.FindByNameAsync(adminRole) is null)
            {
                var admin = new AppUser()
                {
                    Email = adminRole,
                    NickName = adminRole
                };

                var result = await userManager.CreateAsync(admin, adminRole);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }
}
