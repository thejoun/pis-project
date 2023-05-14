using MySqlConnector;
using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    public class MySqlTimelineRepository : ITimelineRepository, IDisposable
    {
        private MySqlConnection _connection;

        private const string query = "SELECT * FROM post";

        public MySqlTimelineRepository(MySqlConnection connection)
        {
            connection.Open();

            _connection = connection;
        }

        public async Task<IEnumerable<Tweet>> GetTweets(int userId)
        {
            await using var command = new MySqlCommand()
            {
                CommandText = query,
                Connection = _connection
            };

            await using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                // var value = reader.GetValue(0);
                
                Console.WriteLine(reader.GetValue(0));
            }

            return Enumerable.Empty<Tweet>();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}