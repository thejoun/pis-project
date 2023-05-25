﻿using Shared.Dtos;
using Shared.Model;

namespace Shared.Mapping;

public static class UserMappingExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Handle = user.Handle,
            Email = user.Email,
            JoinDate = user.JoinDate,
            DisplayName = user.DisplayName
        };
    }

    public static User ToModel(this UserDto user)
    {
        return new User
        {
            Id = user.Id,
            Handle = user.Handle,
            Email = user.Email,
            JoinDate = user.JoinDate,
            DisplayName = user.DisplayName
        };
    }
}