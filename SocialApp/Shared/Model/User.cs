using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")] public int Id { get; set; }
        [Column("handle")] public string? Handle { get; set; }
        [Column("email")] public string? Email { get; set; }
        [Column("join_date")] public DateTime? JoinDate { get; set; }
        [Column("display_name")] public string? DisplayName { get; set; }
    }
}