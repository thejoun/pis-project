using UserTimelineService.Dtos;
using UserTimelineService.Model;

namespace UserTimelineService.Mapping;

public static class PostMappingExtensions
{
    public static PostDto ToDto(this Post post)
    {
        return new PostDto
        {
            Id = post.Id,
            Author = post.Author.ToDto(),
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
            Author = post.Author.ToModel(),
            Header = post.Header,
            Content = post.Content,
            Date = post.Date
        };
    }
}