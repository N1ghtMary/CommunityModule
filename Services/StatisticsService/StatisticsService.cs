using DTO.StatisticsDTO;
using Repository.StatisticsRepository;

namespace Services.StatisticsService;

public class StatisticsService(IStatisticsRepository statisticsRepository ):IStatisticsService
{
    private IStatisticsRepository _statisticsRepository = statisticsRepository;

    public List<StatisticsDTO> GetStatistics()
    {
        return _statisticsRepository.GetAll();
    }

    public List<StatisticsDTO> GetUserStatistics(int id)
    {
        return _statisticsRepository.GetUsers(id);
    }

    public List<StatisticsDTO> GetArticleStatistics(int id)
    {
        return _statisticsRepository.GetArticles(id);
    }

    /*public void ToggleLikeStatistics(ToggleStatisticsDTO dto)
    {
     _statisticsRepository.ToggleLike(dto);   
    }*/

    public void LikeArticle(ToggleStatisticsDTO dto)
    {
        _statisticsRepository.LikeIt(dto);
    }
    public void DislikeArticle(ToggleStatisticsDTO dto)
    {
        _statisticsRepository.DislikeIt(dto);
    }
    public void DeleteStatistics(int id)
    {
        _statisticsRepository.Delete(id);
    }
}