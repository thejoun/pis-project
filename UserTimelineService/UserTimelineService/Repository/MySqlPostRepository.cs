using System.Collections;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Quickwire.Attributes;
using UserTimelineService.Context;
using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    [RegisterService(ServiceLifetime.Singleton, ServiceType = typeof(IPostRepository))]
    public class MySqlPostRepository : IPostRepository, IDisposable
    {
        private MySqlConnection _connection;

        public MySqlPostRepository(MySqlConnection connection)
        {
            connection.Open();

            _connection = connection;
        }

        public async Task<IReadOnlyCollection<Post>> GetPosts(int userId)
        {
            await using (var context = new PostContext())
            {
                List<Post> posts = context.Posts
                    .Include(post => post.Author)
                    .ToList();

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

        public void Dispose()
        {
            _connection.Close();
        }
    }
}