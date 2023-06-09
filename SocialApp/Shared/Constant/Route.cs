namespace Shared.Constant;

public static class Route
{
    public const string Profile = "Profile";
    public const string Timeline = "Timeline";
    public const string Follow = "Follow";

    public const string GetProfileWithHandle = "GetProfile";
    public const string GetProfileWithSub = "GetProfileWithSub";
    public const string CreateProfile = "CreateProfile";
    public const string HasProfileWithSub = "HasProfileWithSub";
    public const string HasProfileWithHandle = "HasProfileWithHandle";

    public const string GetPostsForUserHandle = "GetPosts";
    public const string GetCommentsForUserHandle = "GetComments";
    public const string AddPost = "AddPost";
    public const string AddComment = "AddComment";
    public const string GetHomeTimeline = "GetHomeTimeline";
    public const string GetHomeTimeline2 = "GetHomeTimeline2";

    public const string GetFollowers = "GetFollowers";
    public const string GetFollowing = "GetFollowing";
    public const string AddFollow = "AddFollow";
    public const string RemoveFollow = "RemoveFollow";
    public const string IsFollowing = "IsFollowing";

    public static class Request
    {
        public const string GetProfileWithHandle = Profile + "/" + Route.GetProfileWithHandle + "?user=";
        public const string GetProfileWithSub = Profile + "/" + Route.GetProfileWithSub + "?sub=";
        public const string CreateProfile = Profile + "/" + Route.CreateProfile;
        public const string HasProfileWithSub = Profile + "/" + Route.HasProfileWithSub + "?sub=";
        public const string HasProfileWithHandle = Profile + "/" + Route.HasProfileWithHandle + "?handle=";

        public const string GetPostsForUserHandle = Timeline + "/" + Route.GetPostsForUserHandle + "?user=";
        public const string GetCommentsForUserHandle = Timeline + "/" + Route.GetCommentsForUserHandle + "?user=";
        public const string AddPost = Timeline + "/" + Route.AddPost;
        public const string AddComment = Timeline + "/" + Route.AddComment;

        public static string GetHomeTimeline(string? user, int skip, int take)
            => Timeline + "/" + Route.GetHomeTimeline + $"?user={user}&skip={skip}&take={take}";

        public const string GetFollowers = Follow + "/" + Route.GetFollowers + "?user=";
        public const string GetFollowing = Follow + "/" + Route.GetFollowing + "?user=";
        public const string AddFollow = Follow + "/" + Route.AddFollow;
        public const string RemoveFollow = Follow + "/" + Route.RemoveFollow;

        public static string IsFollowing(string? follower, string? following)
            => Follow + "/" + Route.IsFollowing + $"?follower={follower}&following={following}";
    }
}