using System.Collections.Generic;
using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    public interface ITimelineRepository
    {
        public Task<IEnumerable<Tweet>> GetTweets(int userId);
    }
}