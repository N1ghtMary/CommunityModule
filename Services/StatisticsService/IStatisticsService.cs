using DTO.StatisticsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Services.StatisticsService;

public interface IStatisticsService
{
    List<StatisticsDTO> GetStatistics();
    List<StatisticsDTO> GetUserStatistics(string id);
    List<StatisticsDTO> GetArticleStatistics(int id);
    Task<IActionResult> LikeArticle(ToggleStatisticsDTO dto);
    Task<IActionResult> DislikeArticle(ToggleStatisticsDTO dto);
    void DeleteStatistics(int id);
}