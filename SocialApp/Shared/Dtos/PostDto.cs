using Newtonsoft.Json;

namespace Shared.Dtos
{
    [JsonObject]
    public class PostDto
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("author")] public UserDto? Author { get; set; }
        [JsonProperty("header")] public string? Header { get; set; }
        [JsonProperty("content")] public string? Content { get; set; }
        [JsonProperty("creation_time")] public DateTime Date { get; set; }
    }
}