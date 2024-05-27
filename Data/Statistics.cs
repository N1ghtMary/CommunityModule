using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Statistics
{
    public int StatisticsId { get; set; }
    public int ArticleId { get; set; }
    public bool IsLike { get; set; }
    public string UserId { get; set; }
    
    public User User { get; set; }
    public Article Article { get; set; }
}

public class StatisticsMap
{
    public StatisticsMap(EntityTypeBuilder<Statistics> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.StatisticsId);
        entityTypeBuilder.Property(e => e.ArticleId).IsRequired();
        entityTypeBuilder.Property(e => e.IsLike).IsRequired();
        entityTypeBuilder.Property(e => e.UserId).IsRequired();

        entityTypeBuilder.HasOne(e => e.User)
            .WithMany(e => e.StatisticsList)
            .HasForeignKey(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(e => e.Article)
            .WithMany(e => e.StatisticsList)
            .HasForeignKey(e=>e.ArticleId);
    }
}