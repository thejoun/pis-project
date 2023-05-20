using Newtonsoft.Json;

namespace Shared.Dtos
{
    [JsonObject]
    public class UserDto
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("username")] public string? Username { get; set; }
        [JsonProperty("email")] public string? Email { get; set; }
        [JsonProperty("join_date")] public DateTime JoinDate { get; set; }
    }
}