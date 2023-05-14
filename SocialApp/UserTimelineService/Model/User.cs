using System.ComponentModel.DataAnnotations.Schema;

namespace UserTimelineService.Model
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("username")]
        public string Username { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("join_date")]
        public DateTime JoinDate { get; set; }
    }
}