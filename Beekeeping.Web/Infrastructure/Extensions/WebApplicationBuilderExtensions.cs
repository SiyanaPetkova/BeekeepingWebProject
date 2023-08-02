namespace Beekeeping.Web.Infrastructure.Extensions
{
    using System.Reflection;
    using Beekeeping.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using static Web.Areas.Admin.AdminConstants;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                                         .GetTypes()
                                         .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                                         .ToArray();

            foreach (Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                                         .GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException(
                        $"No interface is provided for the service with name: {implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }
        }

        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }

                var role = new IdentityRole<Guid>(AdministratorRoleName);

                await roleManager.CreateAsync(role);

                var adminUser = await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdministratorRoleName);
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }

    }
}