using Microsoft.AspNetCore.Mvc;
using UserTimelineService.Dtos;
using UserTimelineService.Mapping;
using UserTimelineService.Repository;
using UserTimelineService.Tests;

namespace UserTimelineService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : ControllerBase
    {
        private readonly ILogger<TimelineController> _logger;
        private readonly ITimelineRepository _repository;

        public TimelineController(ITimelineRepository repository, ILogger<TimelineController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("GetTweets")]
        public IEnumerable<TweetDto> GetTweets(int userId)
        {
            return _repository.GetTweets(userId).Result.Select(tweet => tweet.Map());
        }

        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host = "localhost", uint port = 44355)
        {
            var test = new EndpointTest(host, port, _repository);
            
            return $"{test.TestGetTweets()}";
        }
    }
}