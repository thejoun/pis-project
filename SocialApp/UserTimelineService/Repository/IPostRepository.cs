using Shared.Model;

namespace UserTimelineService.Repository
{
    public interface IPostRepository
    {
        public Task<IReadOnlyCollection<Post>> GetPosts(string userHandle);
        public Task AddPost(Post post);
        public Task DeletePost(int id);
        public Task<IReadOnlyCollection<Post>> GetHomeTimelineForUser(string userHandle, int skip, int take);
    }
}