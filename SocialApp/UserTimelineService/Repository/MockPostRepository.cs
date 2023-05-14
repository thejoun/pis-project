using UserTimelineService.Model;

namespace UserTimelineService.Repository
{
    public class MockPostRepository : IPostRepository
    {
        public async Task<IReadOnlyCollection<Post>> GetPosts(int userId)
        {
            return Enumerable.Range(1, 5).Select(number => new Post()
            {
                Author = new User(){Id = userId, Username = $"{userId}", Email = $"{userId}@kakaw.com"},
                Content = new string(number.ToString().FirstOrDefault(), number),
                Date = DateTime.Now + number * TimeSpan.FromDays(1)
            }).ToList();
        }
    }
}