using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Shared.Dtos;
using Shared.Model;
using UserTimelineService.Config;
using UserTimelineService.Context;

namespace UserTimelineService.Repository
{
    public class MySqlCommentRepository : ICommentRepository
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public MySqlCommentRepository(MySqlConnection connection, IOptions<ConnectionStrings> connectionStrings)
        {
            _connection = connection;
            _connectionString = connectionStrings.Value.Default;
        }

        public async Task<IReadOnlyCollection<Comment>> GetComments(string userHandle)
        {
            await _connection.OpenAsync();

            await using var context = new CommentContext(_connectionString);

            var comments = context.Comments.Where(comment => comment.Author.Handle == userHandle);

            await _connection.CloseAsync();

            return comments.ToList();
        }

        public async Task AddComment(Comment comment)
        {
            await _connection.OpenAsync();

            await using var context = new CommentContext(_connectionString);

            await context.Comments.AddAsync(comment);
            // context.Entry(comment.Author).State = EntityState.Unchanged;
            await context.SaveChangesAsync();

            await _connection.CloseAsync();
        }

        public async Task<IReadOnlyCollection<Comment>> GetHomeTimelineForUserComment(string userHandle, int skip, int take)
        {
            await _connection.OpenAsync();

            await using var context = new CommentContext(_connectionString);

            var comments = context.Comments
                .Include(comment => comment.Author)
                //.Where(comment => following.Contains(comment.Author_Id))
                .OrderByDescending(comment => comment.Date)
                .Skip(skip)
                .Take(take);

            await _connection.CloseAsync();

            return comments.ToList();
        }
    }
}