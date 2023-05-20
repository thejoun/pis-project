using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Model
{
    [Table("posts")]
    public class Post
    {
        [Column("id")] public int Id { get; set; }
        [ForeignKey("author_id")]
        [Column("author_id")] public User? Author { get; set; }
        [Column("header")] public string? Header { get; set; }
        [Column("content")] public string? Content { get; set; }
        [Column("creation_time")] public DateTime? Date { get; set; }
    }
}