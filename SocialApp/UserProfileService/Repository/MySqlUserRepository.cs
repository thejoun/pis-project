using Microsoft.EntityFrameworkCore;
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
            await using var context = new UserContext(_connectionString);
            
            // should probably use FindAsync() instead
            // but had some problems with it
            var user = context.Users.FirstOrDefault(user => user.Handle == userHandle);

            await _connection.CloseAsync();
                
            return user;
        }
        
        public async Task<User?> GetUserWithSub(string sub)
        {
            await _connection.OpenAsync();
            await using var context = new UserContext(_connectionString);
            
            var user = context.Users.FirstOrDefault(user => user.Sub != null && user.Sub == sub);

            await _connection.CloseAsync();
                
            return user;
        }
        
        public async Task AddUser(User user)
        {
            await _connection.OpenAsync();
            await using var context = new UserContext(_connectionString);
            
            if (await context.Users.AnyAsync(u => u.Handle == user.Handle))
            {
                return;
            }

            var newUser = new User()
            {
                Handle = user.Handle,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Sub = user.Sub,
                JoinDate = DateTime.Now
            };
            
            await context.Users.AddAsync(newUser);

            await context.SaveChangesAsync();
            
            await _connection.CloseAsync();
        }

        public async Task<bool> HasProfileWithSub(string sub)
        {
            await _connection.OpenAsync();
            await using var context = new UserContext(_connectionString);

            var found = await context.Users.AnyAsync(user => user.Sub == sub);

            await _connection.CloseAsync();

            return found;
        }
        
        public async Task<bool> HasProfileWithHandle(string handle)
        {
            await _connection.OpenAsync();
            await using var context = new UserContext(_connectionString);

            var found = await context.Users.AnyAsync(user => user.Handle == handle);

            await _connection.CloseAsync();

            return found;
        }
    }
}