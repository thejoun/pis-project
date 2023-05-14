using Newtonsoft.Json;
using UserTimelineService.Dtos;
using UserTimelineService.Mapping;
using UserTimelineService.Model;
using UserTimelineService.Repository;

namespace UserTimelineService.Tests;

public class EndpointTest
{
    private readonly string hostUrl;
    private readonly uint port;
    
    private readonly HttpClient httpClient;
    private readonly ITimelineRepository repository;

    public EndpointTest(string hostUrl, uint port, ITimelineRepository repository)
    {
        this.repository = repository;
        this.hostUrl = hostUrl;
        this.port = port;
        
        httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public string TestGetTweets()
    {
        const int userId = 0;

        var fromRepository = repository.GetTweets(userId).Result;
        var fromEndpoint = GetTweets(userId);

        return TestUtility.EqualCount("GetTweets", fromRepository, fromEndpoint);
    }

    private IEnumerable<Tweet> GetTweets(int userId)
    {
        var task = Call(HttpMethod.Get, $"https://{hostUrl}:{port}/Timeline/GetTweets?userId={userId}");
        var result = task.Result;
        
        return DeserializeTweets(result);
    }
    
    private IEnumerable<Tweet> DeserializeTweets(string json)
    {
        var tweets = JsonConvert.DeserializeObject<TweetDto[]>(json) ?? Enumerable.Empty<TweetDto>();
        
        return tweets.Select(dto => dto.Unmap());
    }
    
    private async Task<string> Call(HttpMethod httpMethod, string uri)
    {
        var request = new HttpRequestMessage(httpMethod, uri);
        var response = await httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();
        
        return content;
    }
}