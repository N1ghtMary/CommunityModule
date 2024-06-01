using System.Text.Json.Nodes;
using Data;
using DTO.ArticleDTO;
using DTO.StatisticsDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository.StatisticsRepository;

public class StatisticsRepository(UserManager<User> userManager,
    ApplicationContext context):IStatisticsRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    //private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();

    public List<StatisticsDTO> GetAll()
    {
        var statistics = _statistics
            .Include(s=>s.User)
            .Include(a=>a.Article)
            .ToList();
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statistics)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                Article = new ShowArticleInfoDTO()
                {
                    Author = statistic.Article.Author.Login,
                    Title = statistic.Article.Title
                },
                User = new ShowUserInfoDTO()
                {
                    Login = statistic.User.Login
                }
            });
        }

        return statisticsDtos;
    }

    public List<StatisticsDTO> GetUsers(string id)
    {
        var statiscticsUser = _statistics
            .Include(su=>su.User)
            .Include(a=>a.Article)
            .Where(su => su.UserId == id);
        if (statiscticsUser == null) return null;
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statiscticsUser)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                Article = new ShowArticleInfoDTO()
                {
                    Author = statistic.Article.Author.Login,
                    Title = statistic.Article.Title
                },
                User = new ShowUserInfoDTO()
                {
                    Login = statistic.User.Login
                }
            });
        }

        return statisticsDtos;
    }

    public List<StatisticsDTO> GetArticles(int id)
    {
        var statiscticsArticle = _statistics
            .Include(sa=>sa.User)
            .Include(a=>a.Article)
            .Where(su => su.ArticleId == id);
        if (statiscticsArticle == null) return null;
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statiscticsArticle)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                Article = new ShowArticleInfoDTO()
                {
                    Author = statistic.Article.Author.Login,
                    Title = statistic.Article.Title
                },
                User = new ShowUserInfoDTO()
                {
                    Login = statistic.User.Login
                }
            });
        }

        return statisticsDtos;
    }

   /* public void ToggleLike(ToggleStatisticsDTO dto)
    {
        var user = _users.Where(u => u.UserId == dto.UserId);
        var article = _articles.Where(a => a.ArticleId == dto.ArticleId);
        if (user == null || article == null) return;
        var statistics = _statistics.FirstOrDefault(s => 
            s.UserId == dto.UserId && s.ArticleId == dto.ArticleId);
        if (statistics == null)
        {
            Statistics statisticsNew = new Statistics
            {
                IsLike = true,
                ArticleId = dto.ArticleId,
                UserId = dto.UserId
            };
            _statistics.Add(statisticsNew);
        }
        else
        {
            statistics.IsLike = statistics.IsLike == true ? false : true;
            _statistics.Update(statistics);
        }
        context.SaveChanges();
    }*/

   public async Task<IActionResult> LikeIt(ToggleStatisticsDTO dto)
    {
        var user =await userManager.FindByEmailAsync(dto.User.Email);
        var article = _articles.Where(a => a.ArticleId == dto.ArticleId);
        if (user == null || article == null) return new BadRequestObjectResult("No such user or article");
        var statistics = _statistics.FirstOrDefault(s => 
            s.User.Email == dto.User.Email && s.ArticleId == dto.ArticleId);
        if (statistics == null)
        {
            Statistics statisticsNew = new Statistics
            {
                IsLike = true,
                ArticleId = dto.ArticleId,
                UserId = user.Id
            };
            _statistics.Add(statisticsNew);
        }
        else if (statistics.IsLike == false)
        {
            statistics.IsLike = true;
        }
        else
        {
            _statistics.Remove(statistics);
        }
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public async Task<IActionResult> DislikeIt(ToggleStatisticsDTO dto)
    {
        var user = await userManager.FindByEmailAsync(dto.User.Email);
        var article = _articles.Where(a => a.ArticleId == dto.ArticleId);
        if (user == null || article == null) return new BadRequestObjectResult("No such user or article");;
        var statistics = _statistics.FirstOrDefault(s => 
            s.User.Email == dto.User.Email && s.ArticleId == dto.ArticleId);
        if (statistics == null)
        {
            Statistics statisticsNew = new Statistics
            {
                IsLike = false,
                ArticleId = dto.ArticleId,
                UserId = user.Id
            };
            _statistics.Add(statisticsNew);
        }
        else if (statistics.IsLike == true)
        {
            statistics.IsLike = false;
        }
        else
        {
            _statistics.Remove(statistics);
        }
        await context.SaveChangesAsync();
        return new OkResult();
    }

    public void Delete(int id)
    {
        var statistics =_statistics.SingleOrDefault(s => s.StatisticsId == id);
        if (statistics == null) return;
        _statistics.Remove(statistics);
        context.SaveChanges();
    }
    
    public void SaveChanges()
    {
        context.SaveChanges();
    }
}