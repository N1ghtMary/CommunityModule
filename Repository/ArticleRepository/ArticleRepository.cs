using Data;
using DTO.ArticleDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.ArticleRepository;

public class ArticleRepository(ApplicationContext context):IArticleRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Article> _articles = context.Set<Article>();
    private DbSet<Comments> _comments = context.Set<Comments>();

    public ArticleDTO Get(int Id)
    {
        var article = _articles.SingleOrDefault(a => a.ArticleId == Id);
        if (article == null) return null;
        return new ArticleDTO
        {
             Title = article.Title,
             ArticleText =article.ArticleText,
             ArticlePublicationDate =article.ArticlePublicationDate,
             UserId =article.UserId,
             GroupId =article.GroupId,
             Views =article.Views
        };
    }

    public List<ArticleDTO> GetAll()
    {
        var articles = _articles.ToList();
        List<ArticleDTO> articleDtos = new List<ArticleDTO>();
        foreach (var article in articles)
        {
            articleDtos.Add(new ArticleDTO
            {
                Title = article.Title,
                ArticleText =article.ArticleText,
                ArticlePublicationDate =article.ArticlePublicationDate,
                UserId =article.UserId,
                GroupId =article.GroupId,
                Views =article.Views
            });   
        }

        return articleDtos;
    }

    public void Insert(CreateArticleDTO dto)
    {
        Article article = new Article
        {
            Title = dto.Title,
            ArticleText =dto.ArticleText,
            ArticlePublicationDate =dto.ArticlePublicationDate,
            UserId =dto.UserId,
            GroupId =dto.GroupId,
            Views =dto.Views
        };
        _articles.Add(article);
        context.SaveChanges();
    }

    public void Update(UpdateArticleDTO dto)
    {
        var article = _articles.SingleOrDefault(a => a.ArticleId == dto.ArticleId);
        if (article == null) return;
        article.Title = dto.Title;
        article.ArticleText = dto.ArticleText;
        article.ArticlePublicationDate = dto.ArticlePublicationDate;
        article.UserId = dto.UserId;
        article.GroupId = dto.GroupId;
        article.Views = dto.Views;
        _articles.Update(article);
        context.SaveChanges();
    }

    public void Delete(int Id)
    {
        var article =_articles.SingleOrDefault(a => a.ArticleId == Id);
        if (article == null) return;
        var commentList = _comments
            .Where(cl => cl.ArticleId == article.ArticleId)
            .ToList();
        _comments.RemoveRange(commentList);
        _articles.Remove(article);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        context.SaveChanges();
    }
}