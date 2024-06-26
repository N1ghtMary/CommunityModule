using Data;
using DTO.ArticleDTO;
using DTO.GroupDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Group = System.Text.RegularExpressions.Group;

namespace Repository.ArticleRepository;

public class ArticleRepository(UserManager<User> userManager,
    ApplicationContext context):IArticleRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();
    private DbSet<FavoriteArticle> _favoriteArticles = context.Set<FavoriteArticle>();
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    //private DbSet<User> _users = context.Set<User>();
    private DbSet<Group> _groups = context.Set<Group>();
    
    public ArticleDTO Get(int id)
    {
        var article = _articles
            .Include(g=>g.Group)
            .Include(u=>u.Author)
            .SingleOrDefault(a => a.ArticleId == id);
        if (article == null) return null;
        return new ArticleDTO
        {
             ArticleId = article.ArticleId,
             Title = article.Title,
             ArticleText =article.ArticleText,
             ArticlePublicationDate =article.ArticlePublicationDate,
             User = new ShowUserInfoDTO()
             {
                 Login = article.Author.Login
                // Email = article.Author.Email
             },
             Group = new ShowGroupInfoDTO()
             {
                 GroupName = article.Group.GroupName
             },
             Views =article.Views
        };
    }

    public List<ArticleDTO> GetAll()
    {
        var articles = _articles
            .Include(g=>g.Group)
            .Include(u=>u.Author)
            .ToList();
        List<ArticleDTO> articleDtos = new List<ArticleDTO>();
        foreach (var article in articles)
        {
            articleDtos.Add(new ArticleDTO
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                ArticleText =article.ArticleText,
                ArticlePublicationDate =article.ArticlePublicationDate,
                User = new ShowUserInfoDTO()
                {
                    Login = article.Author.Login
                   // Email = article.Author.Email
                },
                Group = new ShowGroupInfoDTO()
                {
                    GroupName = article.Group.GroupName
                },
                Views =article.Views
            });   
        }

        return articleDtos;
    }

    public async Task<IActionResult> Insert(CreateArticleDTO dto)
    {
       // var author = await userManager.FindByEmailAsync(dto.User.Email);
        var author = await userManager.FindByEmailAsync(dto.User.Email);
        var group = await _groups.SingleOrDefaultAsync(g => g.GroupName == dto.Group.GroupName);
        if(author== null || group == null) return new BadRequestObjectResult("No such user or group");
       // if(group==null) return new BadRequestObjectResult("No such group");
        Article article = new Article
        {
            Title = dto.Title,
            ArticleText =dto.ArticleText,
            ArticlePublicationDate =DateTime.Now,
            UserId = author.Id,
            GroupId = group.GroupId
            //Views =dto.Views
        };
        _articles.Add(article);
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public async Task<IActionResult> Update(UpdateArticleDTO dto)
    {
        var article = await _articles.SingleOrDefaultAsync(a => a.ArticleId == dto.ArticleId);
        var author = await userManager.FindByEmailAsync(dto.User.Email);
        var group = await _groups.SingleOrDefaultAsync(g => g.GroupName == dto.Group.GroupName);
        if(author== null || group==null) return new BadRequestObjectResult("No such user or group");
        if (article == null) return new BadRequestObjectResult("No such article");
        article.Title = dto.Title;
        article.ArticleText = dto.ArticleText;
        article.ArticlePublicationDate = dto.ArticlePublicationDate;
        article.UserId = author.Id;
        article.GroupId = group.GroupId;
        article.Views = dto.Views;
        _articles.Update(article);
        await context.SaveChangesAsync();
        return new OkObjectResult("Article updated");
    }

    public async Task<IActionResult> Views(int id)
    {
        var article = await _articles.SingleOrDefaultAsync(a => a.ArticleId == id);
        if (article == null) return new BadRequestObjectResult("No such article");
        article.Views++;
        _articles.Update(article);
        await context.SaveChangesAsync();
        return new OkResult();
    }
//TODO if after removing article author has no any articles he must lose subscription?
    public async Task<IActionResult> Delete(int id)
    {
        var article = await _articles.SingleOrDefaultAsync(a => a.ArticleId == id);
        if (article == null) return new BadRequestObjectResult("No such article");
        var commentList = _comments
            .Where(cl => cl.ArticleId == article.ArticleId)
            .ToList();
        _comments.RemoveRange(commentList);
        var favoritesArticle = _favoriteArticles.Where(f => f.ArticleId == article.ArticleId);
        _favoriteArticles.RemoveRange(favoritesArticle);

        var statisticsArticle = _statistics.Where(s => s.ArticleId == article.ArticleId);
        _statistics.RemoveRange(statisticsArticle);
        _articles.Remove(article);
        await context.SaveChangesAsync();
        return new OkObjectResult("Deleted");
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}