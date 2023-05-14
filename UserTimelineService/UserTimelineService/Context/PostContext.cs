using Microsoft.EntityFrameworkCore;
using UserTimelineService.Model;

namespace UserTimelineService.Context;

public class PostContext : DbContext
{
    // todo figure out a way to read or inject this
    private const string ConnectionString =
        "Server=pismysqlserv.mysql.database.azure.com;" +
        "User ID=Admin123;" +
        "Password=Password123!;" +
        "Database=twittercopy";

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(ConnectionString,
            ServerVersion.AutoDetect(ConnectionString));
    }
}