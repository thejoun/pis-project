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
            
            var posts = context.Posts.Where(post => post.Author != null 
                                                    && post.Author.Handle == userHandle);

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
    }
}