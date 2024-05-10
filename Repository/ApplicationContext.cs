using Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ApplicationContext(DbContextOptions<ApplicationContext> options): DbContext(options)
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
        new UserMap(modelBuilder.Entity<User>());
    }
}