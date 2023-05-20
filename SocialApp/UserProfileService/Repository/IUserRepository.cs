using Shared.Model;

namespace UserProfileService.Repository
{
    public interface IUserRepository
    {
        public Task<User?> GetUser(string userHandle);
    }
}