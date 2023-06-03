using FollowService.Config;
using FollowService.Context;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Shared.Model;

namespace FollowService.Repository
{
    public class MySqlFollowRepository : IFollowRepository
    {
        private MySqlConnection _connection;
        private string _connectionString;

        public MySqlFollowRepository(MySqlConnection connection, IOptions<ConnectionStrings> connectionStrings)
        {
            _connection = connection;
            _connectionString = connectionStrings.Value.Default;
        }

        public async Task<IReadOnlyCollection<User?>> GetFollowers(string userHandle)
        {
            await _connection.OpenAsync();
            await using var context = new FollowContext(_connectionString);

            var followers = context.Follows
                .Where(follow => follow.FollowingUser != null && follow.FollowingUser.Handle == userHandle)
                .Select(follow => follow.FollowerUser)
                .ToList();

            await _connection.CloseAsync();
            return followers;
        }
        
        public async Task<IReadOnlyCollection<User?>> GetFollowing(string userHandle)
        {
            await _connection.OpenAsync();
            await using var context = new FollowContext(_connectionString);

            var followers = context.Follows
                .Where(follow => follow.FollowerUser != null && follow.FollowerUser.Handle == userHandle)
                .Select(follow => follow.FollowingUser)
                .ToList();

            await _connection.CloseAsync();
            return followers;
        }
        
        public async Task AddFollow(string followerHandle, string followingHandle)
        {
            await _connection.OpenAsync();
            await using var context = new FollowContext(_connectionString);

            if (!TryGetUsers(context, followerHandle, followingHandle, out var follower, out var following))
            {
                return;
            }

            var follow = new Follow()
            {
                FollowerUser = follower,
                FollowingUser = following
            };

            context.Follows.Add(follow);
            await context.SaveChangesAsync();

            await _connection.CloseAsync();
        }

        public async Task RemoveFollow(string followerHandle, string followingHandle)
        {
            await _connection.OpenAsync();
            await using var context = new FollowContext(_connectionString);

            if (!TryGetUsers(context, followerHandle, followingHandle, out var follower, out var following))
            {
                return;
            }

            var followerId = follower?.Id;
            var followingId = following?.Id;

            var follow = context.Follows.FirstOrDefault(follow => follow.Follower == followerId
                                                                  && follow.Following == followingId);

            if (follow is not null)
            {
                context.Follows.Remove(follow);
                
                await context.SaveChangesAsync();
            }

            await _connection.CloseAsync();
        }

        private static bool TryGetUsers(FollowContext context, string followerHandle, string followingHandle,
            out User? follower, out User? following)
        {
            follower = context.Users.FirstOrDefault(user => user.Handle == followerHandle);
            following = context.Users.FirstOrDefault(user => user.Handle == followingHandle);

            if (follower == null)
            {
                Console.WriteLine("Follower is null!");
                return false;
            }

            if (following == null)
            {
                Console.WriteLine("Following is null!");
                return false;
            }

            return true;
        }
    }
}