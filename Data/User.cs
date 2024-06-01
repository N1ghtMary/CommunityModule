using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data;

public class User:IdentityUser
{
   // public int UserId { get; set; }
    //[MaxLength(60)]
   // public string UserFullName { get; set; }
    public DateOnly BirthDate { get; set; }
    [MaxLength(20)]
    public string City { get; set; }
    //[MaxLength(40)]
    //public string Email { get; set; }
    //public long PhoneNumber { get; set; }//
    [MaxLength(20)]
    public string Login { get; set; }
    //[MaxLength(30)]
   // public string Password { get; set; }//

    public List<Article> ArticlesList { get; set; } = new List<Article>();
    public List<Comments> CommentsList { get; set; } = new List<Comments>();
    public List<SubscriptionAuthor> SubscriptionAuthorsList { get; set; }= new List<SubscriptionAuthor>();
    public List<Statistics> StatisticsList { get; set; }= new List<Statistics>();
    public List<FavoriteArticle> FavoriteArticlesList { get; set; }= new List<FavoriteArticle>();
}

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> entityTypeBuilder)
    {
        //entityTypeBuilder.HasKey(e => e.UserId);//no need if :user
        //entityTypeBuilder.Property(e => e.UserFullName).IsRequired();
        //entityTypeBuilder.Property(e => e.City);
        //entityTypeBuilder.Property(e => e.Email);
        //entityTypeBuilder.Property(e => e.PhoneNumber);
        //entityTypeBuilder.Property(e => e.Login);
       // entityTypeBuilder.Property(e => e.Password);
       entityTypeBuilder.Property(e => e.BirthDate);

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