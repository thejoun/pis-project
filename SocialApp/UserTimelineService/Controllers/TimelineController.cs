using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Mapping;
using UserTimelineService.Repository;
using UserTimelineService.Tests;
using Route = Shared.Constant.Route;

namespace UserTimelineService.Controllers
{
    [ApiController]
    [EnableCors]
    [Route(Route.Timeline)]
    public class TimelineController : ControllerBase
    {
        private readonly ILogger<TimelineController> _logger;
        private readonly IPostRepository _repository;

        public TimelineController(IPostRepository repository, ILogger<TimelineController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet] [EnableCors] [Route(Route.GetPostsForUserHandle)]
        public IEnumerable<PostDto> GetPosts(string user) => _repository.GetPosts(user).Result.Select(post => post.ToDto());

        [HttpPost] [EnableCors] [Route(Route.AddPost)]
        public void AddPost(RawPostDto post) => _repository.AddPost(post.ToModel());

        [Obsolete]
        [HttpGet] [Route("RunTests")]
        public string RunTests(string host = "localhost", uint port = 44355)
        {
            var test = new EndpointTest(host, port, _repository);
            
            return $"{test.TestGetTweets()}";
        }
    }
}