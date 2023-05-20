using Shared.Dtos;
using Shared.Model;

namespace Shared.Mapping;

public static class PostMappingExtensions
{
    public static PostDto ToDto(this Post post)
    {
        return new PostDto
        {
            Id = post.Id,
            AuthorId = post.AuthorId,
            Header = post.Header,
            Content = post.Content,
            Date = post.Date
        };
    }

    public static Post ToModel(this PostDto post)
    {
        return new Post
        {
            Id = post.Id,
            AuthorId = post.AuthorId,
            Header = post.Header,
            Content = post.Content,
            Date = post.Date
        };
    }
}