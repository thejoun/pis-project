using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Shared.Dtos;
using Shared.Model;
using UserTimelineService.Config;
using UserTimelineService.Context;

namespace UserTimelineService.Repository
{
    public class MySqlPostRepository : IPostRepository
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public MySqlPostRepository(MySqlConnection connection, IOptions<ConnectionStrings> connectionStrings)
        {
            _connection = connection;
            _connectionString = connectionStrings.Value.Default;
        }

        public async Task<IReadOnlyCollection<Post>> GetPosts(string userHandle)
        {
            await _connection.OpenAsync();

            await using var context = new PostContext(_connectionString);
            
            var posts = context.Posts.Where(post => post.Author.Handle == userHandle);

            await _connection.CloseAsync();
                
            return posts.ToList();
        }
        
        public async Task AddPost(Post post)
        {
            await _connection.OpenAsync();

            await using var context = new PostContext(_connectionString);
            
            await context.Posts.AddAsync(post);
            // context.Entry(post.Author).State = EntityState.Unchanged;
            await context.SaveChangesAsync();

            await _connection.CloseAsync();
        }
        
        public async Task<IReadOnlyCollection<Post>> GetHomeTimelineForUser(string userHandle, int skip, int take)
        {
            await _connection.OpenAsync();

            await using var context = new PostContext(_connectionString);

            var following = context.Follows
                .Where(follow => follow.FollowerUser != null && follow.FollowerUser.Handle == userHandle)
                .Select(follow => follow.Following);

            var posts = context.Posts
                .Include(post => post.Author)
                .Where(post => following.Contains(post.Author_Id))
                .OrderByDescending(post => post.Date)
                .Skip(skip)
                .Take(take);

            await _connection.CloseAsync();
                
            return posts.ToList();
        }
    }
}