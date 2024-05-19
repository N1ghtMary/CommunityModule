using DTO.StatisticsDTO;

namespace Services.StatisticsService;

public interface IStatisticsService
{
    List<StatisticsDTO> GetStatistics();
    List<StatisticsDTO> GetUserStatistics(int id);
    List<StatisticsDTO> GetArticleStatistics(int id);
    void LikeArticle(ToggleStatisticsDTO dto);
    void DislikeArticle(ToggleStatisticsDTO dto);
    void DeleteStatistics(int id);
}