using DTO.StatisticsDTO;

namespace Repository.StatisticsRepository;

public interface IStatisticsRepository
{
    List<StatisticsDTO> GetAll();
    List<StatisticsDTO> GetUsers(int id);
    List<StatisticsDTO> GetArticles(int id);
    void LikeIt(ToggleStatisticsDTO dto);
    void DislikeIt(ToggleStatisticsDTO dto);
    void Delete(int id);
    void SaveChanges();
}