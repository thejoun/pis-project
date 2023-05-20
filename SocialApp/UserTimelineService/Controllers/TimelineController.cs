using System.Security.AccessControl;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Mapping;
using UserTimelineService.Repository;
using UserTimelineService.Tests;

namespace UserTimelineService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : ControllerBase
    {
        private readonly ILogger<TimelineController> _logger;
        private readonly IPostRepository _repository;

        public TimelineController(IPostRepository repository, ILogger<TimelineController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [EnableCors]
        [HttpGet]
        [Route("GetPosts")]
        public IEnumerable<PostDto> GetPosts(string user)
        {
            return _repository.GetPosts(user).Result.Select(post => post.ToDto());
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