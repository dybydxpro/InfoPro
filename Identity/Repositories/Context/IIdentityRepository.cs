using Identity.Modals;

namespace Identity.Repositories.Context
{
    public interface IIdentityRepository
    {
        Task<UserData> FindByIdAsync();
        Task<UserData> FindByIdAsync(string id);
    }
}
