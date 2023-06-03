using Shared.Model;

namespace FollowService.Repository
{
    public interface IFollowRepository
    {
        public Task<IReadOnlyCollection<User?>> GetFollowers(string userHandle);
        public Task<IReadOnlyCollection<User?>> GetFollowing(string userHandle);
        public Task AddFollow(string followerHandle, string followingHandle);
        public Task RemoveFollow(string followerHandle, string followingHandle);
    }
}