using DTO.StatisticsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Repository.StatisticsRepository;

public interface IStatisticsRepository
{
    List<StatisticsDTO> GetAll();
    List<StatisticsDTO> GetUsers(string id);
    List<StatisticsDTO> GetArticles(int id);
    Task<IActionResult> LikeIt(ToggleStatisticsDTO dto);
    Task<IActionResult> DislikeIt(ToggleStatisticsDTO dto);
    void Delete(int id);
    void SaveChanges();
}