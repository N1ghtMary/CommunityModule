using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class Category
{
    public int CategoryId { get; set; }
    [MaxLength(20)]
    public string CategoryName { get; set; }
    
    public List<Group> GroupsList { get; set; }= [];
}

public class CategoryMap
{
    public CategoryMap(EntityTypeBuilder<Category> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.CategoryId);
        entityTypeBuilder.Property(e => e.CategoryName).IsRequired();

        entityTypeBuilder.HasMany(e => e.GroupsList)
            .WithOne(e => e.Category);
    }
}