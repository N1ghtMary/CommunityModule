using System.Text.Json.Nodes;
using Data;
using DTO.StatisticsDTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.StatisticsRepository;

public class StatisticsRepository(ApplicationContext context):IStatisticsRepository
{
    private readonly ApplicationContext _context = context;
    private DbSet<Statistics> _statistics = context.Set<Statistics>();
    private DbSet<User> _users = context.Set<User>();
    private DbSet<Article> _articles = context.Set<Article>();

    public List<StatisticsDTO> GetAll()
    {
        var statistics = _statistics.ToList();
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statistics)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                ArticleId = statistic.ArticleId,
                UserId = statistic.UserId
            });
        }

        return statisticsDtos;
    }

    public List<StatisticsDTO> GetUsers(int id)
    {
        var statiscticsUser = _statistics.Where(su => su.UserId == id);
        if (statiscticsUser == null) return null;
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statiscticsUser)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                ArticleId = statistic.ArticleId,
                UserId = statistic.UserId
            });
        }

        return statisticsDtos;
    }

    public List<StatisticsDTO> GetArticles(int id)
    {
        var statiscticsArticle = _statistics.Where(su => su.ArticleId == id);
        if (statiscticsArticle == null) return null;
        List<StatisticsDTO> statisticsDtos = new List<StatisticsDTO>();
        foreach (var statistic in statiscticsArticle)
        {
            statisticsDtos.Add(new StatisticsDTO
            {
                StatisticsId = statistic.StatisticsId,
                IsLike = statistic.IsLike,
                ArticleId = statistic.ArticleId,
                UserId = statistic.UserId
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

   public void LikeIt(ToggleStatisticsDTO dto)
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
            _statistics.Remove(statistics);
        }
        context.SaveChanges();
    }

    public void DislikeIt(ToggleStatisticsDTO dto)
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
                IsLike = false,
                ArticleId = dto.ArticleId,
                UserId = dto.UserId
            };
            _statistics.Add(statisticsNew);
        }
        else
        {
            _statistics.Remove(statistics);
        }
        context.SaveChanges();
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