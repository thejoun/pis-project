using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Quickwire.Attributes;
using UserTimelineService.Config;
using UserTimelineService.Context;
using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    [RegisterService(ServiceLifetime.Singleton, ServiceType = typeof(IPostRepository))]
    public class MySqlPostRepository : IPostRepository
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public MySqlPostRepository(MySqlConnection connection, IOptions<ConnectionStrings> connectionStrings)
        {
            _connection = connection;
            _connectionString = connectionStrings.Value.Default;
        }

        public async Task<IReadOnlyCollection<Post>> GetPosts(int userId)
        {
            await _connection.OpenAsync();
            
            await using (var context = new PostContext(_connectionString))
            {
                List<Post> posts = context.Posts
                    .Include(post => post.Author)
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