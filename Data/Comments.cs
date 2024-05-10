using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Comments
{
    public int CommentId { get; set; }
    [MaxLength(1000)]
    public string CommentText { get; set; }
    public DateTime CommentPublicationDate { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    
    public User User { get; set; }
    public Article Article { get; set; }
}

public class CommentsMap
{
    public CommentsMap(EntityTypeBuilder<Comments> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.CommentId);
        entityTypeBuilder.Property(e => e.CommentText).IsRequired();
        entityTypeBuilder.Property(e => e.CommentPublicationDate).IsRequired();
        entityTypeBuilder.Property(e => e.UserId).IsRequired();
        entityTypeBuilder.Property(e => e.ArticleId).IsRequired();

        entityTypeBuilder.HasOne(e => e.User)
            .WithMany(e => e.CommentsList)
            .HasForeignKey(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(e => e.Article)
            .WithMany(e => e.CommentsList)
            .HasForeignKey(e=>e.ArticleId);
    }
}