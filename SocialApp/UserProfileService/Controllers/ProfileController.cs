using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Mapping;
using UserProfileService.Repository;

namespace UserProfileService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public ProfileController(IUserRepository repository)
        {
            _repository = repository;
        }

        [EnableCors]
        [HttpGet]
        [Route("GetProfile")]
        public UserDto? GetUser(string user)
        {
            return _repository.GetUser(user).Result?.ToDto();
        }
    }
}