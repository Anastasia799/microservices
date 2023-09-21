using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DbSet<Post> posts, DbSet<Comment> comments) : base(options)
    {
        Posts = posts;
        Comments = comments;
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=147258369");
    }
}