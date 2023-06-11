using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shared.Dtos;
using Shared.Exceptions;
using Shared.Mapping;
using Shared.Model;
using UserProfileService.Repository;
using Xunit;
using Route = Shared.Constant.Route;

namespace Tests;

public class ProfileControllerTests : IAsyncLifetime
{
    private readonly Mock<IUserRepository> _mock = new();

    private HttpClient _httpClient = null!;

    private const string Handle = "foo";

    public async Task InitializeAsync()
    {
        var application = new WebApplicationFactory<UserProfileService.Controllers.Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton(_mock.Object);
                });
            });

        _httpClient = application.CreateClient();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public async Task GetProfile_HappyPath()
    {
        var obj = new User
        {
            Handle = Handle,
            DisplayName = "Test User",
            Email = "test@user.tk",
            FollowerCount = 5,
            FollowingCount = 9,
            Id = 123,
            JoinDate = DateTime.Now,
            Sub = "dchvdhhhhdsi"
        };

        _mock.Setup(repository => repository.GetUser(Handle)).ReturnsAsync(obj);

        var url = $"{Route.Request.GetProfileWithHandle}{Handle}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var returnedJson = await response.Content.ReadAsStringAsync();
        var returnedObject = JsonSerializer.Deserialize<UserDto>(returnedJson)?.ToModel();
        Assert.Equal(obj, returnedObject);
    }

    [Fact]
    public Task GetProfile_NotFound()
    {
        return AssertGetUserHandlesException(new NotFoundException(Handle), HttpStatusCode.NotFound);
    }

    private async Task AssertGetUserHandlesException(Exception exception, HttpStatusCode status)
    {
        _mock.Setup(repository => repository.GetUser(Handle)).ThrowsAsync(exception);

        var url = $"{Route.Request.GetProfileWithHandle}{Handle}";
        var response = await _httpClient.GetAsync(url);
        Assert.Equal(status, response.StatusCode);
    }
}