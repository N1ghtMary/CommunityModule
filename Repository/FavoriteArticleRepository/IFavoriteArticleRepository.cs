using DTO.FavoriteArticleDTO;

namespace Repository.FavoriteArticleRepository;

public interface IFavoriteArticleRepository
{
    List<FavoriteArticleDTO> GetAll();
    List<FavoriteArticleDTO> GetUsers(int id);
    void Insert(CreateFavoriteArticleDTO dto);
    void Delete(int id);
    void SaveChanges();
}