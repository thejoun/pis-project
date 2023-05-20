using Shared.Dtos;
using UserTimelineService.Model;

namespace UserTimelineService.Mapping;

public static class UserMappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            JoinDate = user.JoinDate
        };
    }

    public static User ToModel(this UserDto user)
    {
        return new User
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            JoinDate = user.JoinDate
        };
    }
}