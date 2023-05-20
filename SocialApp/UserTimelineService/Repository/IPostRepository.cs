using Shared.Model;

namespace UserTimelineService.Repository
{
    public interface IPostRepository
    {
        public Task<IReadOnlyCollection<Post>> GetPosts(string userHandle);
    }
}