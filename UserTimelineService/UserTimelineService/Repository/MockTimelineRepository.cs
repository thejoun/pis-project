using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    public class MockTimelineRepository : ITimelineRepository
    {
        public async Task<IEnumerable<Tweet>> GetTweets(int userId)
        {
            return Enumerable.Range(1, 5).Select(number => new Tweet()
            {
                Owner = new User(){Id = userId, Username = $"{userId}", Email = $"{userId}@kakaw.com"},
                Content = new string(number.ToString().FirstOrDefault(), number),
                Date = DateTime.Now + number * TimeSpan.FromDays(1)
            });
        }
    }
}