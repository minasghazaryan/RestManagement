using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RestManagement.Shared.Roles;

namespace RestManagement.DataAccess.Seed
{
    public class RoleSeed
    {
        public static async Task Init(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.EnsureCreatedAsync();

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = RoleNames.Client });
                await roleManager.CreateAsync(new IdentityRole { Name = RoleNames.Manager });
                await roleManager.CreateAsync(new IdentityRole { Name = RoleNames.Waiter });
            }
        }
    }
}
