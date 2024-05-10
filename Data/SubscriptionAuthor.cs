using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class SubscriptionAuthor
{
    public int SubscriptionId { get; set; }
    public bool IsActive { get; set; }
    public int AuthorId { get; set; }
    public int UserId { get; set; }
    
    public User User { get; set; }
    public User Author { get; set; }
}

public class SubscriptionAuthorMap
{
    public SubscriptionAuthorMap(EntityTypeBuilder<SubscriptionAuthor> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.SubscriptionId);
        entityTypeBuilder.Property(e => e.IsActive).IsRequired();
        entityTypeBuilder.Property(e => e.AuthorId).IsRequired();
        entityTypeBuilder.Property(e => e.UserId).IsRequired();

        entityTypeBuilder.HasOne(e => e.User)
            .WithMany(e => e.SubscriptionAuthorsList)
            .HasForeignKey(e=>e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        entityTypeBuilder.HasOne(e => e.Author)
            .WithMany()
            .HasForeignKey(e=>e.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}