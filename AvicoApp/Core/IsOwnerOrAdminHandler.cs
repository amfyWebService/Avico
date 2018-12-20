using System.Threading.Tasks;
using AvicoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AvicoApp.Core
{
    public class IsOwnerOrAdminHandler : AuthorizationHandler<IsOwnerOrAdminRequirement>
    {
        private UserManager<ApplicationUser> _userManager;

        public IsOwnerOrAdminHandler(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsOwnerOrAdminRequirement requirement)
        {
            ApplicationUser user = await this._userManager.GetUserAsync(context.User);

            if(user == null){
                context.Fail();
                return;
            }

            IIsOwner resource = context.Resource as IIsOwner;
            if(resource != null) {
                if(resource.IsOwner(user) || context.User.IsInRole("Admin")){
                    context.Succeed(requirement);
                } else {
                    context.Fail();
                }
            }

            return;
        }
    }
}