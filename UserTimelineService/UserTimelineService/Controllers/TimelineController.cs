using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserTimelineService.Dtos;
using UserTimelineService.Repository;

namespace UserTimelineService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MorgueController : ControllerBase
    {
        private readonly ILogger<MorgueController> logger;
        private readonly ITimelineRepository repository;

        public MorgueController(ITimelineRepository repository, ILogger<MorgueController> logger)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        [Route("GetTweets")]
        public IEnumerable<TweetDto> GetTweets(int userId)
        {
            return repository.GetTweets(userId).Select(person => person.Map());
        }

        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host = "localhost", uint port = 44355)
        {
            var test = new Test(host, port, repository);
            return $"{test.TestGetPeople()}\n{test.TestGetShelves()}";
        }
    }
}