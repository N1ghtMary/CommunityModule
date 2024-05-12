using DTO.StatisticsDTO;

namespace Repository.StatisticsRepository;

public interface IStatisticsRepository
{
    List<StatisticsDTO> GetAll();
    List<StatisticsDTO> GetUsers(int id);
    List<StatisticsDTO> GetArticles(int id);
    void ToggleLike(int userId, int articleId);
    void SaveChanges();
}