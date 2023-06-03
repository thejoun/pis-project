namespace Shared.Constant;

public static class Route
{
    public const string Profile = "Profile";
    public const string Timeline = "Timeline";

    public const string GetProfileWithHandle = "GetProfile";
    public const string GetProfileWithSub = "GetProfileWithSub";
    public const string CreateProfile = "CreateProfile";
    public const string HasProfileWithSub = "HasProfileWithSub";
    public const string HasProfileWithHandle = "HasProfileWithHandle";
    public const string GetPostsForUserHandle = "GetPosts";
    public const string AddPost = "AddPost";
    
    public static class Request
    {
        public const string GetProfileWithHandle = Profile + "/" + Route.GetProfileWithHandle + "?user=";
        public const string GetProfileWithSub = Profile + "/" + Route.GetProfileWithSub + "?sub=";
        public const string CreateProfile = Profile + "/" + Route.CreateProfile;
        public const string HasProfileWithSub = Profile + "/" + Route.HasProfileWithSub + "?sub=";
        public const string HasProfileWithHandle = Profile + "/" + Route.HasProfileWithHandle + "?handle=";
        public const string GetPostsForUserHandle = Timeline + "/" + Route.GetPostsForUserHandle + "?user=";
        public const string AddPost = Timeline + "/" + Route.AddPost;
    }
}