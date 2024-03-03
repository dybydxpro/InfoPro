using Identity.Modals;

namespace Identity.Repositories.Context
{
    public interface IUserRepository
    {
        Task<User> GetUserData();

        Task<User> GetUserDataById(string id);
        void AddUser(User user);
    }
}
