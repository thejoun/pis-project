using System;

namespace UserTimelineService.Model
{
    public class Tweet
    {
        public User Owner { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}