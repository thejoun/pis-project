using System;
using Newtonsoft.Json;

namespace UserTimelineService.Dtos
{
    [JsonObject]
    public class TweetDto
    {
        public UserDto Owner { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}