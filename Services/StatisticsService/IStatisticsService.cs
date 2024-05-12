using DTO.StatisticsDTO;

namespace Services.StatisticsService;

public interface IStatisticsService
{
    List<StatisticsDTO> GetStatistics();
    List<StatisticsDTO> GetUserStatistics(int id);
    List<StatisticsDTO> GetArticleStatistics(int id);
    void ToggleLikeStatistics(ToggleStatisticsDTO dto);
}