using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")] public int Id { get; set; }
        [Column("sub")] public string? Sub { get; set; }
        [Column("handle")] public string? Handle { get; set; }
        [Column("email")] public string? Email { get; set; }
        [Column("join_date")] public DateTime? JoinDate { get; set; }
        [Column("display_name")] public string? DisplayName { get; set; }
        [Column("follower_count")] public int? FollowerCount { get; set; }
        [Column("following_count")] public int? FollowingCount { get; set; }
    }
}