using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class User//:IdentityUser
{
    public int UserId { get; set; }//
    [MaxLength(60)]
    public string UserFullName { get; set; }
    public DateTime BirthDate { get; set; }
    [MaxLength(20)]
    public string City { get; set; }
    [MaxLength(40)]
    public string Email { get; set; }//
    public long PhoneNumber { get; set; }//
    [MaxLength(20)]
    public string Login { get; set; }
    [MaxLength(30)]
    public string Password { get; set; }//

    public List<Article> ArticlesList { get; set; } = [];
    public List<Comments> CommentsList { get; set; } = [];
    public List<SubscriptionAuthor> SubscriptionAuthorsList { get; set; }= [];
    public List<Statistics> StatisticsList { get; set; }= [];
    public List<FavoriteArticle> FavoriteArticlesList { get; set; }= [];
}

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.UserId);//no need if :user
        entityTypeBuilder.Property(e => e.UserFullName).IsRequired();
        entityTypeBuilder.Property(e => e.City);
        entityTypeBuilder.Property(e => e.Email);
        entityTypeBuilder.Property(e => e.PhoneNumber);
        entityTypeBuilder.Property(e => e.Login);
        entityTypeBuilder.Property(e => e.Password);

        entityTypeBuilder.HasMany(e => e.ArticlesList)
            .WithOne(e => e.Author);
        entityTypeBuilder.HasMany(e => e.CommentsList)
            .WithOne(e => e.User);
        entityTypeBuilder.HasMany(e => e.SubscriptionAuthorsList)
            .WithOne(e => e.User);
        entityTypeBuilder.HasMany(e => e.StatisticsList)
            .WithOne(e => e.User);
        entityTypeBuilder.HasMany(e => e.FavoriteArticlesList)
            .WithOne(e => e.User);
    }
}