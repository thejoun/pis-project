using UserTimelineService.Dtos;
using UserTimelineService.Model;

namespace UserTimelineService.Mapping
{
    public static class TweetMappingExtensions
    {
        public static TweetDto Map(this Tweet tweet)
        {
            return new TweetDto
            {
                Owner = tweet.Owner.Map(),
                Date = tweet.Date,
                Content = tweet.Content
            };
        }

        public static Tweet Unmap(this TweetDto tweet)
        {
            return new Tweet
            {
                Owner = tweet.Owner.Unmap(),
                Date = tweet.Date,
                Content = tweet.Content
            };
        }
    }
}