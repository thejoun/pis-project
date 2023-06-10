using Shared.Model;

namespace UserTimelineService.Repository
{
    public interface ICommentRepository
    {
        public Task<IReadOnlyCollection<Comment>> GetComments();
        public Task AddComment(Comment comment);
        public Task<IReadOnlyCollection<Comment>> GetHomeTimelineForUserComment(int skip, int take);
    }
}