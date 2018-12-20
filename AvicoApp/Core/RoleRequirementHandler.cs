using System.Threading.Tasks;
using AvicoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AvicoApp.Core
{
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        private UserManager<ApplicationUser> _userManager;

        public RoleRequirementHandler(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            bool isAuthorized = false;
            ApplicationUser user = await this._userManager.GetUserAsync(context.User);

            if(user == null){
                context.Fail();
                return;
            }

            for(int i = 0; i < requirement.roles.Length; i++){
                if(await this._userManager.IsInRoleAsync(user, requirement.roles[i])){
                    isAuthorized = true;
                }
            }

            if(isAuthorized){
                context.Succeed(requirement);
            } else {
                context.Fail();
            }
        }
    }
}