using DTO.FavoriteArticleDTO;
using Repository.FavoriteArticleRepository;

namespace Services.FavoriteArticleService;

public class FavoriteArticleService(IFavoriteArticleRepository favoriteArticleRepository):IFavoriteArticleService
{
    private IFavoriteArticleRepository _favoriteArticleRepository = favoriteArticleRepository;

    public List<FavoriteArticleDTO> GetFavoriteArticles()
    {
        return _favoriteArticleRepository.GetAll();
    }
    
    public List<FavoriteArticleDTO> GetUserFavoriteArticles(int id)
    {
        return _favoriteArticleRepository.GetUsers(id);
    }

    public void InsertFavoriteArticle(CreateFavoriteArticleDTO dto)
    {
        _favoriteArticleRepository.Insert(dto);
    }

    public void DeleteFavoriteArticle(int id)
    {
        _favoriteArticleRepository.Delete(id);
    }
}