using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    public interface IPostRepository
    {
        public Task<IReadOnlyCollection<Post>> GetPosts(int userId);
    }
}