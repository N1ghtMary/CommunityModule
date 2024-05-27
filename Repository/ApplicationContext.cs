using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationContext(DbContextOptions<ApplicationContext> options): 
    IdentityUserContext<User>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new ArticleMap(modelBuilder.Entity<Article>());
        new CategoryMap(modelBuilder.Entity<Category>());
        new CommentsMap(modelBuilder.Entity<Comments>());
        new FavoriteArticleMap(modelBuilder.Entity<FavoriteArticle>());
        new GroupMap(modelBuilder.Entity<Group>());
        new StatisticsMap(modelBuilder.Entity<Statistics>());
        new SubscriptionAuthorMap(modelBuilder.Entity<SubscriptionAuthor>());
        //new UserMap(modelBuilder.Entity<User>());
        //modelBuilder.Entity<User>().Property(u => u.BirthDate);
        //modelBuilder.Entity<User>().Property(u => u.);
    }
}