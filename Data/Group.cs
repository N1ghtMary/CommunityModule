using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Group
{
    public int GroupId { get; set; }
    [MaxLength(20)]
    public string GroupName { get; set; }
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    public List<Article> ArticlesList { get; set; }= [];
}

public class GroupMap
{
    public GroupMap(EntityTypeBuilder<Group> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.GroupId);
        entityTypeBuilder.Property(e => e.GroupName).IsRequired();

        entityTypeBuilder.HasOne(e => e.Category)
            .WithMany(e => e.GroupsList)
            .HasForeignKey(e=>e.CategoryId);
        entityTypeBuilder.HasMany(e => e.ArticlesList)
            .WithOne(e => e.Group);
    }
}
