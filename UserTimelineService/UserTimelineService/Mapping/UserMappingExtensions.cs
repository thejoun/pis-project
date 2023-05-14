using UserTimelineService.Dtos;
using UserTimelineService.Model;

namespace UserTimelineService.Mapping
{
    public static class UserMappingExtensions
    {
        public static UserDto Map(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        public static User Unmap(this UserDto user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}