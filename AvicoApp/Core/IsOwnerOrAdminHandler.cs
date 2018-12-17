using System.Threading.Tasks;
using AvicoApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AvicoApp.Core
{
    public class IsOwnerOrAdminHandler : AuthorizationHandler<IsOwnerOrAdminRequirement>
    {

        public IsOwnerOrAdminHandler()
        {
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsOwnerOrAdminRequirement requirement)
        {
            if(!context.User.Identity.IsAuthenticated){
                context.Fail();
                return;
            }

            IIsOwner resource = context.Resource as IIsOwner;
            if(resource != null) {
                // ApplicationUser user = await this.userManager.GetUserAsync(context.User);
                // if(resource.IsOwner(user) || context.User.IsInRole("Admin")){
                //     context.Succeed(requirement);
                // } else {
                //     context.Fail();
                // }
            }

            return;
        }
    }
}