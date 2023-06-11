using System.Net;
using System.Text.Json;
using Moq;
using Shared.Constant;
using Shared.Dtos;
using Shared.Exceptions;
using Shared.Mapping;
using Xunit;

namespace Tests.Integration;

public partial class ProfileControllerTests
{
    [Fact]
    public async Task GetProfile_Handle()
    {
        _mock.Setup(repository => repository.GetUser(Handle)).ReturnsAsync(User);

        var url = $"{Route.Request.GetProfileWithHandle}{Handle}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var returnedJson = await response.Content.ReadAsStringAsync();
        var returnedObject = JsonSerializer.Deserialize<UserDto>(returnedJson)?.ToModel();
        Assert.Equal(User, returnedObject);
    }

    [Fact]
    public Task GetProfile_Handle_NotFound()
    {
        return AssertGetProfileHandlesException(new NotFoundException(Handle), HttpStatusCode.NotFound);
    }

    private async Task AssertGetProfileHandlesException(Exception exception, HttpStatusCode status)
    {
        _mock.Setup(repository => repository.GetUser(Handle)).ThrowsAsync(exception);

        var url = $"{Route.Request.GetProfileWithHandle}{Handle}";
        var response = await _httpClient.GetAsync(url);
        Assert.Equal(status, response.StatusCode);
    }
    
    [Fact]
    public async Task GetProfile_Sub()
    {
        _mock.Setup(repository => repository.GetUserWithSub(Sub)).ReturnsAsync(User);

        var url = $"{Route.Request.GetProfileWithSub}{Sub}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var returnedJson = await response.Content.ReadAsStringAsync();
        var returnedObject = JsonSerializer.Deserialize<UserDto>(returnedJson)?.ToModel();
        Assert.Equal(User, returnedObject);
    }

    [Fact]
    public Task GetProfile_Sub_NotFound()
    {
        return AssertGetProfileWithSubHandlesException(new NotFoundException(Sub), HttpStatusCode.NotFound);
    }

    private async Task AssertGetProfileWithSubHandlesException(Exception exception, HttpStatusCode status)
    {
        _mock.Setup(repository => repository.GetUserWithSub(Sub)).ThrowsAsync(exception);

        var url = $"{Route.Request.GetProfileWithSub}{Sub}";
        var response = await _httpClient.GetAsync(url);
        Assert.Equal(status, response.StatusCode);
    }
}