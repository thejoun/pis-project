using Microsoft.Extensions.Options;
using MySqlConnector;
using Shared.Model;
using UserProfileService.Config;
using UserProfileService.Context;

namespace UserProfileService.Repository
{
    public class MySqlUserRepository : IUserRepository
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public MySqlUserRepository(MySqlConnection connection, IOptions<ConnectionStrings> connectionStrings)
        {
            _connection = connection;
            _connectionString = connectionStrings.Value.Default;
        }

        public async Task<User?> GetUser(string userHandle)
        {
            await _connection.OpenAsync();
            
            await using (var context = new UserContext(_connectionString))
            {
                // should probably use FindAsync() instead
                // but had some problems with it
                var user = context.Users.FirstOrDefault(user => user.Handle == userHandle);

                await _connection.CloseAsync();
                
                return user;
            }
        }
    }
}