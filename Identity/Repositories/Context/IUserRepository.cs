using Identity.Modals;

namespace Identity.Repositories.Context
{
    public interface IUserRepository
    {
        Task<User> GetUserData();
        void AddUser(User user);
    }
}
