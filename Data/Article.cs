using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Article
{
    public int ArticleId { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    public string ArticleText { get; set; }
    public DateTime ArticlePublicationDate { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public int Views { get; set; }
    
    public List<Comments> CommentsList { get; set; }= [];
    public List<FavoriteArticle> FavoriteArticlesList { get; set; }= [];
    public List<Statistics> StatisticsList { get; set; }= [];
    public Group Group { get; set; }
    public User Author { get; set; }
}

public class ArticleMap
{
    public ArticleMap(EntityTypeBuilder<Article> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.ArticleId);
        entityTypeBuilder.Property(e => e.Title).IsRequired();
        entityTypeBuilder.Property(e => e.ArticleText).IsRequired();
        entityTypeBuilder.Property(e => e.ArticlePublicationDate).IsRequired();
        entityTypeBuilder.Property(e => e.UserId).IsRequired();
        entityTypeBuilder.Property(e => e.GroupId).IsRequired();
        entityTypeBuilder.Property(e => e.Views).IsRequired();

        entityTypeBuilder.HasOne(e => e.Author)
            .WithMany(e => e.ArticlesList)
            .HasForeignKey(e=>e.UserId);
        entityTypeBuilder.HasOne(e => e.Group)
            .WithMany(e => e.ArticlesList)
            .HasForeignKey(e=>e.GroupId);
        entityTypeBuilder.HasMany(e => e.CommentsList)
            .WithOne(e => e.Article);
        entityTypeBuilder.HasMany(e => e.FavoriteArticlesList)
            .WithOne(e => e.Article);
        entityTypeBuilder.HasMany(e => e.StatisticsList)
            .WithOne(e => e.Article);
    }
}