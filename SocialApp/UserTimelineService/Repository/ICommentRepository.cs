using Shared.Model;

namespace UserTimelineService.Repository
{
    public interface ICommentRepository
    {
        public Task<IReadOnlyCollection<Comment>> GetComments(string userHandle);
        public Task AddComment(Comment comment);
        public Task<IReadOnlyCollection<Comment>> GetHomeTimelineForUserComment(string userHandle, int skip, int take);
    }
}