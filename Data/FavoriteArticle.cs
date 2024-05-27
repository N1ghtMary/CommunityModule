using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class FavoriteArticle
{
    public int FavoriteId { get; set; }
    public int ArticleId { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public Article Article { get; set; }
}

public class FavoriteArticleMap
{
    public FavoriteArticleMap(EntityTypeBuilder<FavoriteArticle> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.FavoriteId);

        entityTypeBuilder.HasOne(e => e.User)
            .WithMany(e => e.FavoriteArticlesList)
            .HasForeignKey(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(e => e.Article)
            .WithMany(e => e.FavoriteArticlesList)
            .HasForeignKey(e=>e.ArticleId);
    }
}