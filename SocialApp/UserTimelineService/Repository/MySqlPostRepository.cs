using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
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
            
            await using (var context = new PostContext(_connectionString))
            {
                var posts = context.Posts
                    // .Include(post => post.Author)    // not needed here, as we know the author already
                    .ToList();

                await _connection.CloseAsync();
                
                return posts;
            }
            
            // await using var command = new MySqlCommand()
            // {
            //     CommandText = query,
            //     Connection = _connection
            // };
            //
            // await using var reader = await command.ExecuteReaderAsync();
            //
            // while (await reader.ReadAsync())
            // {
            //     // var value = reader.GetValue(0);
            //     
            //     Console.WriteLine(reader.GetValue(0));
            // }
            //
            // return Enumerable.Empty<Post>();
        }
    }
}