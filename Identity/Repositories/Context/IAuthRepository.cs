using Identity.Modals;
using Identity.Modals.Auth;

namespace Identity.Repositories.Context
{
    public interface IAuthRepository
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);
        Task<(int, string)> RegisterationUser(User model, string role);
    }
}
