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
        private readonly ICommentRepository _repositoryComment;

        private readonly IUCLRepository _repositoryUCL;

        public TimelineController(IPostRepository repository, ILogger<TimelineController> logger, ICommentRepository repositoryComment, IUCLRepository repositoryUCL)
        {
            _logger = logger;
            _repository = repository;
            _repositoryComment = repositoryComment;
            _repositoryUCL = repositoryUCL;
        }

        [HttpGet]
        [EnableCors]
        [Route(Route.GetPostsForUserHandle)]
        public IEnumerable<PostDto> GetPosts(string user) => _repository.GetPosts(user).Result.Select(post => post.ToDto());

        [HttpGet]
        [EnableCors]
        [Route(Route.GetComments)]
        public IEnumerable<CommentDto> GetComments() => _repositoryComment.GetComments().Result.Select(comment => comment.ToDto());

        [HttpGet]
        [EnableCors]
        [Route(Route.GetUCL)]
        public IEnumerable<User_CommentLikedDto> GetUCL() => _repositoryUCL.GetUCL().Result.Select(ucl => ucl.ToDto());

        [HttpPost]
        [EnableCors]
        [Route(Route.AddPost)]
        public void AddPost(RawPostDto post) => _repository.AddPost(post.ToModel());

        [HttpPost]
        [EnableCors]
        [Route(Route.AddComment)]
        public void AddComment(RawCommentDto comment) => _repositoryComment.AddComment(comment.ToModel());

        [HttpPost]
        [EnableCors]
        [Route(Route.AddLike)]
        public void AddLike(RawCommentDto comment) => _repositoryComment.AddLike(comment.ToModel());

        [HttpPost]
        [EnableCors]
        [Route(Route.AddUCL)]
        public void AddUCL(User_CommentLikedDto ucl) => _repositoryUCL.AddUCL(ucl.ToModel());

        [HttpPost]
        [EnableCors]
        [Route(Route.RemoveUCL)]
        public void RemoveUCL(User_CommentLikedDto ucl) => _repositoryUCL.RemoveUCL(ucl.ToModel());


        [HttpGet]
        [EnableCors]
        [Route(Route.GetHomeTimeline)]
        public IEnumerable<PostDto> GetHomeTimelineForUser(string user, int skip, int take)
            => _repository.GetHomeTimelineForUser(user, skip, take).Result.Select(post => post.ToDto());

        // not sure what it was supposed to do
        // [HttpGet]
        // [EnableCors]
        // [Route(Route.GetHomeTimeline2)]
        // public IEnumerable<CommentDto> GetHomeTimelineForUserComment(int skip, int take)
        //             => _repositoryComment.GetHomeTimelineForUserComment(skip, take).Result.Select(comment => comment.ToDto());

        [Obsolete]
        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host = "localhost", uint port = 44355)
        {
            var test = new EndpointTest(host, port, _repository);

            return $"{test.TestGetTweets()}";
        }
    }
}