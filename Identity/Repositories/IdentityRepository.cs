using Identity.Modals;
using Identity.Modals.Auth;
using Identity.Repositories.Context;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string userIdentifier;

        public IdentityRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            try
            {
                userIdentifier = contextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserData> FindByIdAsync()
        {
            var user = await _userManager.FindByIdAsync(userIdentifier);
            return new UserData(user.Id, user.AuthId, user.FirstName, user.LastName, user.UserName, user.Email);
        }

        public async Task<UserData> FindByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new UserData(user.Id, user.AuthId, user.FirstName, user.LastName, user.UserName, user.Email);
        }
    }
}
