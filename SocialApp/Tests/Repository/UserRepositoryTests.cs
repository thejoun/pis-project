using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Shared.Exceptions;
using Shared.Model;
using UserProfileService.Repository;
using Xunit;

namespace Tests.Repository;

public class UserRepositoryTests : IAsyncLifetime
{
    private IUserRepository Repo { get; set; }

    private IServiceScope Scope { get; set; }
    private string Handle { get; set; }
    private User User { get; set; }
    
    public async Task InitializeAsync()
    {
        var application = new WebApplicationFactory<UserProfileService.Program>()
            .WithWebHostBuilder(builder => { builder.ConfigureServices(_ => { }); });
        
        // i create it manually beacuse of issues with DI here
        var connectionString =
            "Server=pismysqlserv.mysql.database.azure.com;Uid=Admin123;Pwd=Password123!;Database=twittercopy";
        var connection = new MySqlConnection(connectionString);
        Repo = new MySqlUserRepository(connection, connectionString);

        var random = new Random();

        Handle = Guid.NewGuid().ToString();
        
        User = new User
        {
            Handle = Handle,
            DisplayName = Guid.NewGuid().ToString(),
            Email = Guid.NewGuid().ToString(),
            FollowerCount = random.Next(),
            FollowingCount = random.Next(),
            JoinDate = DateTime.Today,
            Sub = Guid.NewGuid().ToString()
        };
    }

    public async Task DisposeAsync()
    {
        try
        {
            await Repo.DeleteUser(Handle);
        }
        catch (NotFoundException)
        {
            // nothing to clean up
        }
    }

    [Fact]
    public async Task AddProfile()
    {
        await Repo.AddUser(User);
        var storedProfile = await Repo.GetUser(Handle);
        Assert.True(storedProfile?.Id > 0);
        storedProfile.Id = 0;
        Assert.Equal(User, storedProfile);
    }

    [Fact]
    public async Task AddProfile_AlreadyExists()
    {
        await Repo.AddUser(User);
        await Assert.ThrowsAsync<AlreadyExistsException>(() => Repo.AddUser(User));
    }

    [Fact]
    public async Task GetProfile_NotFound()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => Repo.GetUser(Handle));
    }

    [Fact]
    public async Task DeleteProfile()
    {
        await Repo.AddUser(User);
        await Repo.DeleteUser(Handle);
        await GetProfile_NotFound();
    }

    [Fact]
    public async Task DeleteProfile_NotFound()
    {
        await Assert.ThrowsAsync<NotFoundException>(() => Repo.DeleteUser(Handle));
    }
}