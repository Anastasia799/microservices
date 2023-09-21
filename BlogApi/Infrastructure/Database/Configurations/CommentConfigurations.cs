using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Database.Configurations;

public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(x => x.Post)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.PostId);
    }
}