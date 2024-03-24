using Identity.Data;
using Identity.Modals;
using Identity.Repositories.Context;

namespace Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityRepository _identityRepository;

        public UserRepository(ApplicationDbContext dbContext, IIdentityRepository identityRepository)
        {
            _dbContext = dbContext;
            _identityRepository = identityRepository;
        }

        public async Task<User> GetUserData()
        {
            var identityUser = await _identityRepository.FindByIdAsync();
            return _dbContext.Users.Where(u => u.UserIdentifier == identityUser.Id).FirstOrDefault();
        }

        public async Task<User> GetUserDataById(string id)
        {
            return _dbContext.Users.Where(u => u.UserIdentifier == id).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
