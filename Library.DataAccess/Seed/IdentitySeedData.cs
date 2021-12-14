using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Seed
{
    public class IdentitySeedData
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole adminRole = new IdentityRole
                {
                    Name = "Admin"
                };

                IdentityResult result = roleManager.CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole userRole = new IdentityRole
                {
                    Name = "User"
                };

                IdentityResult result = roleManager.CreateAsync(userRole).Result;
            }

            if (userManager.FindByEmailAsync("admin@xyz.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Haslo123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Haslo123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
    }
}
