using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Mapping;
using UserProfileService.Repository;
using Route = Shared.Constant.Route;

namespace UserProfileService.Controllers
{
    [ApiController]
    [Route(Route.Profile)]
    [EnableCors]
    public class ProfileController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public ProfileController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] [EnableCors] [Route(Route.GetProfileWithHandle)]
        public UserDto? GetProfile(string user) => _repository.GetUser(user).Result?.ToDto();

        [HttpGet] [EnableCors] [Route(Route.GetProfileWithSub)]
        public UserDto? GetProfileWithSub(string sub) => _repository.GetUserWithSub(sub).Result?.ToDto();
        
        [HttpPost] [EnableCors] [Route(Route.CreateProfile)]
        public void CreateProfile(UserDto user) => _repository.AddUser(user.ToModel());

        [HttpGet] [EnableCors] [Route(Route.HasProfileWithSub)]
        public bool IsSubRegistered(string sub) => _repository.HasProfileWithSub(sub).Result;

        [HttpGet] [EnableCors] [Route(Route.HasProfileWithHandle)]
        public bool IsHandleRegistered(string handle) => _repository.HasProfileWithHandle(handle).Result;
    }
}