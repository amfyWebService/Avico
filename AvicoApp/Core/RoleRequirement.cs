using Microsoft.AspNetCore.Authorization;

namespace AvicoApp.Core
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public string[] roles {get; private set;}

        public RoleRequirement(params string[] roles)
        {
            this.roles = roles;
        }
    }
}