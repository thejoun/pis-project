using System;

namespace UserTimelineService.Dtos
{
    public class TweetDto
    {
        public UserDto Owner { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}