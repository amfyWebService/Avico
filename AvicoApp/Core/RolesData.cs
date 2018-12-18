using System;
using System.Threading.Tasks;
using AvicoApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace AvicoApp.Core {
    public static class RolesData {

        private static readonly string[] Roles = new string[] {
            "Admin",
            "Moderator",
            "Manager",
            "Client"
        };

        public static async Task SeedRoles (IServiceProvider serviceProvider) {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory> ().CreateScope ()) {
                var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext> ();

                if (dbContext.Database.GetPendingMigrations ().Any ()) {
                    await dbContext.Database.MigrateAsync ();
                }

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>> ();

                foreach (var role in Roles) {
                    if (!await roleManager.RoleExistsAsync (role)) {
                        await roleManager.CreateAsync (new IdentityRole (role));
                    }
                }
            }
        }

        public static void DefinePolicies (IServiceCollection services) {
            services.AddAuthorization (options => {
                options.AddPolicy ("RequireManager", policy => policy.RequireRole ("Admin", "Manager"));
                options.AddPolicy ("RequireManagerAndOwner", policy => policy
                    .RequireRole ("Admin", "Manager")
                    .AddRequirements(new IsOwnerOrAdminRequirement())
                );
                // options.AddPolicy ("RequireModerator", policy => policy.RequireRole ("Admin", "Moderator"));
                options.AddPolicy ("RequireClient", policy => policy.RequireRole ("Admin", "Client"));
                options.AddPolicy ("RequireClientAndOwner", policy => policy
                    .RequireRole ("Admin", "Client")
                    .AddRequirements(new IsOwnerOrAdminRequirement())
                );
            });

            services.AddSingleton<IAuthorizationHandler , IsOwnerOrAdminHandler>();
        }
    }
}