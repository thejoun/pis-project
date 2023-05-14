using System.ComponentModel.DataAnnotations.Schema;

namespace UserTimelineService.Model
{
    public class Post
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("AuthorId")]
        public User Author { get; set; }

        [Column("header")]
        public string Header { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("creation_time")]
        public DateTime Date { get; set; }
    }
}